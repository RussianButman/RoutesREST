# RoutesREST

Тестовое Web API приложение для обхода маршрутов.

- Чтение и запись информации в СУБД с использованием CodeFirst Migrations EFCore
- Простая авторизация пользователя (логин, пароль или пин-код)
- Создание, изменение маршрутов с контрольными точками
- Привязка NFC меток к контрольным точкам по уникальным идентификаторам
- Получение списка маршрутов
- Запуск обхода маршрута, считывание NFC меток

Приложение выполнено на платформе ASP.NET.
В качестве БД использовалась PostgreSQL.
Для взаимодействия с БД использовалась Entity Framework Core с подходом Code First.

В приложении представлено три контроллера:
- HomeController
- AdminController
- AccountController

Контроллер HomeController содержит методы для получения списка маршрутов и отметки о прохождении точек маршрута
Контроллер AdminController содержит методы, предназначенные для администраторов (добавление, редактирование, удаление маршрутов/точек маршрутов), привязка NFC-меток.
Контроллер AccountController содержит методы для авторизации и регистрации пользователей.

 # HomeController
 
 ## Get All Routes
 
 Получает список всех маршрутов
 
 **URL**: `/api/getroutes`
 **Method**: `GET`
 **Auth requires**: YES
 **Permissions required**: None
 
 ### Success responses
 **Code**: `200 OK`
 **Content**: 
 ```json
 [
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "performer": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "name": "string",
      "bypassRoute": "string",
      "routeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    },
    "location": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "latitude": 0,
      "longitude": 0,
      "bypassRoute": "string",
      "bypassRouteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    },
    "bypassRoutePoints": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "bypassRouteIndex": 0,
        "location": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "latitude": 0,
          "longitude": 0,
          "bypassRoutePoint": "string",
          "bypassRoutePointId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        },
        "bypassDatetimes": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "dateTime": "2022-12-05T00:46:39.083Z",
            "bypassRoutePoint": "string",
            "routePointId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
          }
        ],
        "nfcTagId": "string",
        "bypassRoute": "string",
        "routeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
      }
    ],
    "bypassDatetimes": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "dateTime": "2022-12-05T00:46:39.083Z",
        "bypassRoute": "string",
        "routeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
      }
    ]
  }
]
```
