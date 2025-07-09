# 📊 Diagramas do Projeto Chatbot

Este documento contém os diagramas de entidades, classes e fluxo do projeto **Chatbot Inteligente**.

---

## 🧠 1. Fluxo de Conversa (Mermaid)

```mermaid
sequenceDiagram
    participant Usuário
    participant Bot
    participant Suporte

    Usuário->>Bot: Tenho um problema
    Bot->>Usuário: Certo! Qual o problema?
    Usuário->>Bot: Não consigo acessar o sistema RH
    Bot->>Usuário: Já tentou limpar cache?
    Usuário->>Bot: Sim
    Bot->>Usuário: Redirecionando para o suporte
    Bot->>Suporte: Enviar transcrição e notificar atendimento
```

---

## 🗃️ 2. Diagrama Entidade-Relacionamento (simplificado)

```mermaid
erDiagram
    USUARIO ||--o{ SESSAO : possui
    USUARIO ||--o{ MENSAGEM : envia
    SESSAO ||--o{ MENSAGEM : contém

    USUARIO {
        int Id
        string Nome
    }

    SESSAO {
        int Id
        datetime Inicio
        datetime Fim
    }

    MENSAGEM {
        int Id
        string Texto
        datetime Timestamp
        string Origem
        string Intencao
    }
```

---

## 🧱 3. Diagrama de Classes (backend)

```mermaid
classDiagram
    class ChatHub {
        +SendMessage()
        +ReceiveMessage()
    }

    class ChatFlowService {
        +ProcessMessage(text)
        +GetNextStep()
    }

    class Message {
        +int Id
        +string Texto
        +DateTime Timestamp
        +string Origem
        +string Intencao
    }

    ChatHub --> ChatFlowService
    ChatFlowService --> Message
```

---

## 📍 Localização no Projeto

Este arquivo pode ser encontrado em: `docs/diagramas.md`
