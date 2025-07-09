import styles from "./styles.module.css";

import { useState, useEffect, useRef } from "react";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const Chat = () => {
  const [messages, setMessages] = useState([
    { id: 1, text: "Olá, como posso ajudar?", origin: "bot" },
    { id: 2, text: "Preciso de ajuda com meu cadastro", origin: "user" },
  ]);
  const [newMessage, setNewMessage] = useState("");

  const connectionRef = useRef(null);
  const messagesEndRef = useRef(null);

  useEffect(() => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:6001/chatHub")
      .configureLogging(LogLevel.Information)
      .build();

    connectionRef.current = connection;

    connection
      .start()
      .then(() => {
        console.log("🔌 Conectado ao SignalR");
      })
      .catch((err) => console.error("❌ Erro na conexão SignalR:", err));

    connection.on("ReceiveMessage", (message) => {
      const botMsg = {
        id: Date.now(),
        text: message.text,
        origin: message.user?.toLowerCase() === "bot" ? "bot" : "user",
      };

      setMessages((prev) => [...prev, botMsg]);
    });

    return () => {
      connection.stop();
    };
  }, [messages]);

  return (
    <section className={styles.chat}>
      <div className={styles.messages}>
        {messages.map((msg) => (
          <div
            key={msg.id}
            className={
              msg.origin === "user" ? styles.userMessage : styles.botMessage
            }
          >
            {msg.text}
          </div>
        ))}
        <div ref={messagesEndRef} />
      </div>
      <form
        className={styles.inputArea}
        onSubmit={(e) => {
          e.preventDefault();

          if (!newMessage.trim()) return;

          const dto = {
            user: "user",
            text: newMessage,
          };

          setNewMessage("");

          connectionRef.current
            ?.invoke("SendMessage", dto)
            .catch((err) => console.error("Erro ao enviar mensagem:", err));
        }}
      >
        <input
          type="text"
          placeholder="Digite sua mensagem..."
          value={newMessage}
          onChange={(e) => setNewMessage(e.target.value)}
          aria-label="Campo de entrada de mensagem"
        />

        <button type="submit">Enviar</button>
      </form>
    </section>
  );
};
