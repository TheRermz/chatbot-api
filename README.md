# 🤖 Chatbot Inteligente — Projeto com .NET + React

## 🧾 1. Apresentação

Este projeto implementa um chatbot inteligente com as seguintes funcionalidades:

- Atendimento automatizado em tempo real
- Identificação da intenção do usuário
- Respostas automáticas baseadas em regras ou IA local
- Redirecionamento para atendimento humano quando necessário

Tecnologias utilizadas:

- **Backend:** ASP.NET Core 8 + SignalR
- **Frontend:** React (Vite) + SignalR Client
- **IA Local (futuro):** LLaMA via Ollama/LocalAI (Docker)
- **Persistência (futuro):** PostgreSQL ou SQLite

---

## ⚙️ 2. Funcionalidades

### MVP Inicial

- Comunicação em tempo real com SignalR
- Respostas automáticas com base em palavras-chave
- Estrutura de roteamento por intenção
- Interface de chat funcional (React)

### Futuras Funcionalidades

- Persistência do histórico
- Autenticação com JWT
- Integração com IA local
- Interface mobile (PWA ou React Native)

---

## 🧑‍💻 3. Casos de Uso

| #   | Caso de Uso         | Descrição                                      |
| --- | ------------------- | ---------------------------------------------- |
| 1   | Início de conversa  | Envio de saudação automática                   |
| 2   | Resposta automática | Bot interpreta e responde com base na intenção |
| 3   | Redirecionamento    | Encaminhamento ao suporte humano               |
| 4   | Integração com IA   | Resposta gerada via modelo local (ex: LLaMA)   |

---

## 🧠 4. Fluxo de Conversa Exemplo

```bash
Usuário → Bot: "Tenho um problema"
Bot → Usuário: "Certo! Qual o problema?"
Usuário → Bot: "Não consigo acessar o sistema RH"
Bot → Usuário: "Já tentou limpar o cache?"
Usuário → Bot: "Sim"
Bot → Usuário: "Ok, redirecionando para o suporte."
```

---

## 🗂 5. Estrutura do Projeto

```bash
chatbot/
├── backend/           # ASP.NET Core + SignalR
├── frontend/          # React + Vite
├── chatbot.sln        # Solução .NET
```

---

## 🧱 6. Arquitetura

- ASP.NET Web API com SignalR
- React com conexão WebSocket (SignalR)
- IA local (LLaMA2) via Ollama ou LocalAI (futuro)
- Banco de dados (opcional nas fases iniciais)

---

## Diagramas

Consulte os [docs/diagramas.md](docs/diagramas.md) para ver os diagramas de fluxo, ER e classes.

---

## 🔌 8. Integrações Futuras

- IA local com Docker (Ollama)
- Autenticação JWT
- Exportação de histórico
- Versão mobile

---

## ✅ 9. Checklist

Ver arquivo [docs/checklist.md](docs/checklist.md) para controle de desenvolvimento.

---

## 🔐 10. Licença

Projeto em desenvolvimento para fins educacionais. Licença a definir.
