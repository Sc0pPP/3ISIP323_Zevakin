# Практическая работа №8 — Интернет-магазин (Entity Framework)

Консольный интернет-магазин на C# с базой данных, группа 3ИСИП-323. Работа лежит в проекте **ConsoleApp2**.

## Возможности

- регистрация (с подтверждением пароля) и вход по логину и паролю;
- просмотр товаров;
- добавление товаров в корзину;
- оформление заказа с выбором пункта выдачи (ПВЗ);
- история заказов с составом каждого.

## База данных

| Таблица | Поля |
|---------|------|
| `users` | ID, Login, passwrod |
| `tovary` | ID, Name, Price, Description |
| `cart` | ID, UsersID, TovarID |
| `order` | ID, UsersID, TovarID, PvzID |
| `TovaryOrader` | TovarID, OrderID, TVID |
| `pvz` | ID, Addres |

## Технологии

- C#, .NET Framework 4.7.2
- Entity Framework 6 (Database First, `Model.edmx`)
- SQL Server, база `shop`

## Запуск

1. Создайте в SQL Server базу `shop` с таблицами выше.
2. При необходимости поправьте строку подключения в `ConsoleApp2/App.config`.
3. Откройте `3ISIP323_Zevakin.sln` в Visual Studio и запустите проект `ConsoleApp2`.
