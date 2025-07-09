# ✅ Chatbot com .NET + React — Checklist Atualizado

## 🎯 Objetivo do Projeto

Desenvolver um chatbot inteligente que:

- Interage com o usuário via chat em tempo real
- Compreende a intenção da mensagem
- Dá instruções automáticas quando possível
- Redireciona para o suporte humano quando necessário
- Usa backend em .NET 8 e frontend em React
- IA opcional via modelo local como LLaMA (rodando em homelab via Docker)

---

## ✅ Fase 1 — MVP Funcional (sem IA, sem banco)

### Backend (.NET 8)

- [ ] Criar projeto ASP.NET Core Web API
- [ ] Implementar SignalR (`ChatHub.cs`)
- [ ] Criar lógica de roteamento com base em palavras-chave/intenção
- [ ] Criar estrutura para fluxo de conversas (estágios e intenções)
- [ ] Simular respostas automáticas com base em intenção
- [ ] Endpoint REST opcional para teste (`/api/messages`)
- [ ] Permitir fallback de redirecionamento para “suporte”

### Frontend (React + Vite)

- [ ] Criar interface básica de chat (campo de entrada, envio, exibição)
- [ ] Conectar ao SignalR Hub
- [ ] Exibir mensagens com bolhas e scroll automático
- [ ] Simular entrada de atendente humano após redirecionamento
- [ ] Estilizar interface para uso mobile (sem Tailwind)

---

## 🔄 Fase 2 — Persistência de dados

### Banco de Dados

- [ ] Adicionar SQLite ou PostgreSQL
- [ ] Criar tabela `Messages` com (Id, User, Texto, Timestamp, Origem, Intenção)
- [ ] Armazenar histórico das conversas
- [ ] Endpoint para recuperar histórico (`GET /api/messages`)
- [ ] Relacionar conversas com sessões/usuários fictícios

---

## 🔐 Fase 3 — Autenticação e Sessão (opcional)

- [ ] Implementar JWT para simular usuários distintos
- [ ] Salvar token no frontend para identificar usuário
- [ ] Associar mensagens por usuário/sessão

---

## 🤖 Fase 4 — IA de intenção (via modelo local)

### IA com Ollama ou LocalAI

- [ ] Instalar IA local (Ollama) no homelab com Docker
- [ ] Carregar modelo (ex: llama2:chat ou mistral)
- [ ] Criar chamada do backend para o endpoint da IA local
- [ ] Substituir roteador de palavras-chave pela IA
- [ ] IA deve retornar intenção e resposta com base no prompt
- [ ] Manter histórico de mensagens no prompt (simples contexto)

---

## 🧠 Fluxo de conversa esperado

- [ ] Início com saudação automatizada
- [ ] Identificação da intenção inicial (ex: problema, solicitação, dúvida)
- [ ] Coleta de informações adicionais com perguntas condicionais
- [ ] Resposta final automática ou redirecionamento
- [ ] Entrada do atendente humano (simulado)

---

## 🚀 Fase 5 — Mobile (opcional/futuro)

- [ ] Adaptar interface web para PWA ou criar versão em React Native
- [ ] Conectar com SignalR
- [ ] Estilizar para uso mobile com experiência fluida
- [ ] Notificações locais (em caso de respostas do bot/humano)

---

## 🧰 Extras e melhorias

- [ ] Adicionar comandos secretos ou easter eggs
- [ ] Criar sistema de sugestões automáticas conforme usuário digita
- [ ] Exportar conversa em PDF ou texto
- [ ] Dark mode e acessibilidade
- [ ] Logs de conversas e respostas automáticas para análise

---

## 🧱 Infraestrutura

- [ ] Criar container Docker para backend
- [ ] Servir frontend com Nginx ou build estático
- [ ] IA local e backend no mesmo `docker-compose`
- [ ] Monitorar recursos do sistema (htop, Glances)
