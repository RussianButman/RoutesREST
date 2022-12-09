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

# Авторизация

Авторизация реализована на основе токенов (JWT)

Чтобы получить доступ к методам и контроллерам, требующим авторизции, нужно в заголовке запроса указать заголовок:

```json
{
 "Authorization": "Bearer <token>"
}
```

# AccountController

Используется для входа и регистрации

Включает следующие методы:

## Login

Метод авторизации

**URL**: `/api/account/login`

**Method**: `POST`

**Auth requires**: NO

**Permissions required**: None

**Data constraints**:

Нужно указать логин и пароль.

```json
{
 "username": "[unicode 64 chars max]",
 "password": "[unicode 64 chars max]"
}
```

Пример ввода данных:

```json
{
 "username": "RussianButman",
 "password": "passW0rd123$"
}
```

## Register

Метод для регистрации пользвоателя.

**URL**: `/api/account/register`

**Method**: `POST`

**Auth requires**: NO

**Permissions required**: None

**Data constraints**:

Нужно указать логин, пароль и ФИО.

```json
{
 "username": "[unicode 64 chars max]",
 "password": "[unicode 64 chars max]",
 "fullName": "[unicode 64 chars max]",
 "email": "[unicode 64 chars max]",
 "phoneNumber": "[unicode 64 chars max]"
}
```

Пример ввода данных:

```json
{
 "username": "RussianButman",
 "password": "passW0rd123$",
 "fullName": "Фамилия Имя Отчество",
 "email": "email@example.com",
 "phoneNumber": "+79999999999"
}
```


## Register Admin

Метод для регистрации нового администратора. Требует прав администратора.

**URL**: `/api/account/register`

**Method**: `POST`

**Auth requires**: YES

**Permissions required**: Admin

**Data constraints**:

Нужно указать логин, пароль и ФИО.

```json
{
 "username": "[unicode 64 chars max]",
 "password": "[unicode 64 chars max]",
 "fullName": "[unicode 64 chars max]",
 "email": "[unicode 64 chars max]",
 "phoneNumber": "[unicode 64 chars max]"
}
```

Пример ввода данных:

```json
{
 "username": "RussianButman",
 "password": "passW0rd123$",
 "fullName": "Фамилия Имя Отчество",
 "email": "email@example.com",
 "phoneNumber": "+79999999999"
}
```

# HomeController

Основной конттроллер для исполнителей обходов маршрутов.

## Get Routes

Метод для получения всех маршрутов.

**URL**: `/api/getroutes`

**Method**: `GET`

**Auth requires**: YES

**Permissions required**: None

### Success responses
 
 **Code**: `200 OK`
 
 **Content**: 
 `BypassRoute array`
 
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

## Get Route by Id

Метод для получения объекта маршрута по идентификатору.

**URL**: `/api/getroutesbyid`

**Method**: `GET`

**Auth requires**: YES

**Permissions required**: None

### Success responses

**Code**: `200 OK`

**Content**:
`BypassRoute instance`

```json
{
    "performer": {
        "id": "84a0142c-26a7-4948-99ae-1367d1279349",
        "name": "Фамилия Имя Отчество",
        "bypassRoute": null,
        "routeId": "e7f037f1-1c86-4023-96e5-b97b04bfc93c"
    },
    "location": {
        "id": "14f451f2-009a-4e11-94f3-6998f6b7c73a",
        "latitude": 20.001,
        "longitude": 110.0002,
        "bypassRoute": null,
        "bypassRouteId": "e7f037f1-1c86-4023-96e5-b97b04bfc93c"
    },
    "bypassRoutePoints": [
        {
            "id": "4668edca-85f4-44b6-aec5-ba07f7872fe4",
            "bypassRouteIndex": 1,
            "location": {
                "id": "a50132fe-8d72-46cc-9e8e-2b12c0ceb37d",
                "latitude": 10.0004,
                "longitude": 110.0005,
                "bypassRoutePoint": null,
                "bypassRoutePointId": "4668edca-85f4-44b6-aec5-ba07f7872fe4"
            },
            "bypassDatetimes": [
                {
                    "id": "ef24b64c-3cd1-4f47-8575-fc51e2b41a07",
                    "dateTime": "2022-12-03T02:11:12.029Z",
                    "bypassRoutePoint": null,
                    "routePointId": "4668edca-85f4-44b6-aec5-ba07f7872fe4"
                }
            ],
            "nfcTagId": "",
            "bypassRoute": null,
            "routeId": "e7f037f1-1c86-4023-96e5-b97b04bfc93c"
        }
    ],
    "bypassDatetimes": [],
    "lazyLoader": {},
    "id": "e7f037f1-1c86-4023-96e5-b97b04bfc93c",
    "name": "string"
}
```

## Check Route Point

Отметить обход точки маршрута текущим временем сервера.

**URL**: `/api/checkroutepoint?routePointId`

**URL Parameters**: `routePointId` - идентификатор точки маршрута

**Method**: `PATCH`

**Auth requires**: YES

**Permissions required**: None

### Success responses

**Code** `200 OK`

**Content**: 
`BypassRoutePoint instance`

```json
{
    "id": "4668edca-85f4-44b6-aec5-ba07f7872fe4",
    "bypassRouteIndex": 1,
    "location": {
        "id": "a50132fe-8d72-46cc-9e8e-2b12c0ceb37d",
        "latitude": 10.0004,
        "longitude": 110.0005,
        "bypassRoutePoint": null,
        "bypassRoutePointId": "4668edca-85f4-44b6-aec5-ba07f7872fe4"
    },
    "bypassDatetimes": [
        {
            "id": "ef24b64c-3cd1-4f47-8575-fc51e2b41a07",
            "dateTime": "2022-12-03T02:11:12.029Z",
            "bypassRoutePoint": null,
            "routePointId": "4668edca-85f4-44b6-aec5-ba07f7872fe4"
        }
    ],
    "nfcTagId": "",
    "bypassRoute": null,
    "routeId": "e7f037f1-1c86-4023-96e5-b97b04bfc93c"
}
```

## Check Route

Отметить обход маршрута текущим временем сервера.

**URL**: `/api/checkroute?routeId`

**URL Parameters**: `routeId` - идентификатор маршрута

**Method**: `PUT`

**Auth requires**: YES

**Permissions required**: None

**Data constraints**

```json
{
  "beginDateTime": "2022-12-09T00:31:21.272Z",
  "endDateTime": "2022-12-09T00:31:21.272Z"
}
```

### Success responses

**Code** `200 OK`

**Content**:
`BypassRoute instance`

## Get My Routes

Получить список маршрутов текущего пользователя.

**URL**: `/api/admin/getmyroutes`

**Method**: `GET`

**Auth requires**: YES

**Permissions required**: None

### Success responses

**Code** `200 OK`

**Content**: `BypassRouteInstance list`

# AdminController

Контроллер для администраторов

## Add Bypass Route

Добавить маршрут.

**URL**: `/api/admin/addbypassroute`

**Method**: `PUT`

**Auth requires**: YES

**Permissions required**: Admin

### Success responses

**Code** `200 OK`

**Content**:

```json
{
    "name": "string",
    {
     "Latitude": 0,
     "Longitude": 0
    }
}
```

## Edit Bypass Route

Редактирование маршрута по заданному идентификатору.

**URL**: `/api/admin/editbypassroute`

**Method**: `PATCH`

**Auth requires**: YES

**Permissions required**: Admin

**Data constraints**: `BypassRoute instance`

### Success responses

**Code** `200 OK`

**Content**: `BypassRoutePoint instance`

## Delete Bypass Route Point

Удаление маршрута по заданному идентификатору.

**URL**: `/api/admin/deletebypassroute?routeId`

**URL Parameters**: `routeId` - идентификатор маршрута

**Method**: `DELETE`

**Auth requires**: YES

**Permissions required**: Admin

### Success responses

**Code** `200 OK`

## Add Bypass Route Point

Добавить точку в заданном маршруте.

**URL**: `/api/admin/addbypassroutepoint/:routeId`

**Method**: `PUT`

**Auth requires**: YES

**Permissions required**: Admin

### Success responses

**Code** `200 OK`

**Content**: `BypassRoutePoint instance`

## Assign Performer By Id

Назначить пользователя по идентификатору в качестве исполнителя для заданного по идентификатору маршрута.

**URL**: `/api/admin/assignperformer?userId&routeId`

**Method**: `PATCH`

**Auth requires**: YES

**Permissions required**: Admin

### Success responses

**Code** `200 OK`

**Content**: `BypassRoute instance`

## Assign Nfc Tag

Назначить идентификатор NFC-метки заданной точке.

**URL**: `/api/admin/assignperformer?routePointId&nfcTagUid`

**Method**: `PATCH`

**Auth requires**: YES

**Permissions required**: Admin

### Success responses

**Code** `200 OK`

**Content**: `BypassRoutePoint instance`
