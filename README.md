
# 💳 Финансовая система обработки транзакций (Pet-проект)

Этот pet-проект — учебная система обработки финансовых транзакций с приёмом данных через API, очередями, логированием, уведомлениями и микросервисной архитектурой. Проект создан для прокачки навыков backend-разработки на C# и .NET Core до уровня Senior.

---

## 🔍 Описание

Проект имитирует реальную финансовую платформу, где пользовательские транзакции:
- Принимаются через защищённый Web API
- Помещаются в очередь на обработку
- Обрабатываются фоновыми сервисами
- Сохраняются в базу данных
- Сопровождаются логами и уведомлениями

---

## 🧱 Архитектура

- ASP.NET Core Web API (REST + JWT)
- BackgroundService + Channel (Producer/Consumer)
- Dapper или EF Core (на выбор)
- Serilog + Seq для логирования
- Telegram и Email уведомления
- Docker + Docker Compose
- Unit + Integration тесты
- GitHub Actions (CI/CD)

---

## 📦 Функциональные блоки

| Модуль | Описание |
|--------|----------|
| **API** | Приём транзакций, Swagger, авторизация |
| **Очередь** | Асинхронная обработка транзакций |
| **Хранилище** | Работа с БД через Dapper/EF |
| **Уведомления** | Отправка Email и Telegram |
| **Логирование** | Serilog + Middleware для ошибок |
| **Тесты** | Unit и Integration |
| **DevOps** | Docker + CI/CD pipeline |

---

## 🧠 Цели проекта

- Применить .NET Core в архитектуре реального уровня
- Освоить микросервисные паттерны, очереди и контейнеризацию
- Прокачать тестирование, DevOps, логирование и безопасность

---

## 🚀 Как запустить

1. Клонируй репозиторий:
```bash
git clone https://github.com/your-username/fin-system.git
```

2. Построй контейнеры:
```bash
docker-compose up --build
```

3. Открой Swagger:
```
http://localhost:5000/swagger
```

---

## 🛠 Технологии

- C# 12, .NET 8
- ASP.NET Core Web API
- Dapper / EF Core
- Serilog, Seq
- Docker, GitHub Actions
- xUnit, Moq

---

## 📌 Статус

🔧 В активной разработке — задачи ведутся через [GitHub Projects](https://github.com/YOUR_USERNAME/fin-system/projects)

---

## 👨‍💻 Автор

Doniyor Botirov — .NET разработчик и инженер по архитектуре
