# Web API

### Get Notes List
#### Request (parameterless)
```
GET /api/notes
```

#### Result Code on Success: `200 OK`
#### Result JSON
Array of objects with the following fields
| Field | Type | Description |
|--|--|--|
| **id** | integer | ID of the note |
| **title** | string | Title of the note |

#### Response Example
```js
[
  { 
    "id": "1", 
    "title": "Books to read" 
  }, 
  { 
    "id": "2", 
    "title": "Mega Idea"
  }
]
```

----

### Get Note Content
#### Request
```
GET /api/notes/{id}
```

#### Result Code on Success: `200 OK`
#### Result JSON
| Field | Type | Description |
|--|--|--|
| **id** | integer | ID of the note |
| **title** | string | Title of the note |
| **content** | string | Text of the note |

#### Response Example
```js
{
  "id": "2",
  "title": "Mega Idea",
  "content": "Design a room in the Skyrim style"
}
```

----

### Add New Note
#### Request
```
POST /api/notes
```

#### Request Parameters JSON
| Field | Type | Description |
|--|--|--|
| **title** | string | Title of the new note |
| **content** | string | Text of the new note |

#### Request Parameters Example
```js
{
  "title": "Just DO IT",
  "content": "Yesterday you said tomorrow. So just DO IT!"
}
```

#### Result Code on Success: `201 Created`
#### Result JSON
| Field | Type | Description |
|--|--|--|
| **id** | integer | ID of the newly inserted note |

#### Response Example
```js
{
  "id": "10"
}
```

----

### Edit Existing Note
#### Request
```
PUT /api/notes/{id}
```

#### Request Parameters JSON
| Field | Type | Description |
|--|--|--|
| **title** | string | New title of the new note |
| **content** | string | New text of the new note |

#### Request Parameters Example
```js
{
  "title": "Just DO IT. Yes YOU CAN!",
  "content": "Don't let your dreams be dreams. Yesterday you said tomorrow. So just DO IT!"
}
```

#### Result Code on Success: `200 OK`
#### Result JSON: No

----

### Delete Note
#### Request
```
DELETE /api/notes/{id}
```

#### Request Parameters JSON: No
#### Result Code on Success: `200 OK`
#### Result JSON: No
