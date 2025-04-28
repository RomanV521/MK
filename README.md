### Variant 3

API для цитат — генератор случайной цитаты

### Сущности: ЦИТАТА, ТЕГ, АВТОР

### Функционал: 
Добавление/обновление/удаление цитат

У цитаты может быть несколько тегов и только 1 автор

Тэги добавляются автоматически по мере добавления цитат

Получение списка тегов

Добавление/обновление/удаление авторов

Получение случайной(!) цитаты + фильтр по тегу


Будет плюсом: авторизация(автор цитаты тот кто ее добавил), Получение списка тегов выводить только те теги по которым есть цитаты

### API:
```sh
http://localhost:5051/swagger/index.html
```

### Test SQL scripts

Users:
```sh
INSERT INTO public."Users" ("Id", "Username", "PasswordHash")
VALUES
	(1, 'john_doe', 'hash1234009'),
	(2, 'jane_smith', 'hash1234469'),
	(3, 'alice_wonder', 'hash1234349'),
	(4, 'mike_brown', 'hash1234659'),
	(5, 'emma_white', 'hash1234119'),
	(6, 'oliver_jones', 'hash1234439'),
	(7, 'sophia_green', 'hash1234109'),
	(8, 'liam_clark', 'hash1234099'),
	(9, 'ava_moore', 'hash1234779'),
	(10, 'noah_wilson', 'hash1234339'),
	(11, 'mia_taylor', 'hash1234067'),
	(12, 'ella_baker', 'hash1234015'),
  (13, 'user12r', 'hash1adda433');
```

Authors:
```sh
INSERT INTO public."Authors" ("Id", "Name")
VALUES
	(1, 'John Doe'),
	(2, 'Jane Smith'),
	(3, 'Alice Wonder'),
	(4, 'Mike Brown'),
	(5, 'Emma White'),
	(6, 'Oliver Jones'),
	(7, 'Sophia Green'),
	(8, 'Liam Clark'),
	(9, 'Ava Moore'),
	(10, 'Noah Wilson'),
	(11, 'Mia Taylor'),
	(12, 'Ella Baker'),
	(13, 'Benjamin Cooper');
```

Tags:
```sh
INSERT INTO public."Tags" ("Id", "Name")
VALUES
	(1, 'Motivation'),
	(2, 'Success'),
	(3, 'Life'),
	(4, 'Wisdom'),
	(5, 'Love'),
	(6, 'Happiness'),
	(7, 'Friendship'),
	(8, 'Courage'),
	(9, 'Hope'),
	(10, 'Inspiration'),
	(11, 'Dreams'),
	(12, 'Strength'),
	(13, 'Kindness'),
	(14, 'Learning'),
	(15, 'Adventure'),
	(16, 'Creativity'),
	(17, 'Mindfulness'),
	(18, 'Leadership'),
	(19, 'Philosophy'),
	(20, 'Humor');
```

Quotes:
```sh
INSERT INTO public."Quotes" ("Id", "Text", "AuthorId", "CreatedById")
VALUES
	(1, 'Believe you can and you are halfway there.', 1, 1),
	(2, 'The only limit to our realization of tomorrow is our doubts of today.', 2, 2),
	(3, 'Success is not the key to happiness. Happiness is the key to success.', 3, 3),
	(4, 'Keep your face always toward the sunshine—and shadows will fall behind you.', 4, 4),
	(5, 'What lies behind us and what lies before us are tiny matters compared to what lies within us.', 5, 5),
	(6, 'Act as if what you do makes a difference. It does.', 6, 6),
	(7, 'Success usually comes to those who are too busy to be looking for it.', 7, 7),
	(8, 'Do not wait. The time will never be just right.', 8, 8),
	(9, 'Life is what happens when you are busy making other plans.', 9, 9),
	(10, 'The purpose of our lives is to be happy.', 10, 10),
	(11, 'Turn your wounds into wisdom.', 11, 11),
	(12, 'Dream big and dare to fail.', 12, 12),
	(13, 'Your time is limited, so do not waste it living someone else’s life.', 13, 13),
	(14, 'Do what you can, with what you have, where you are.', 1, 4),
	(15, 'Believe in yourself and all that you are.', 3, 2),
	(16, 'In the middle of every difficulty lies opportunity.', 12, 1),
	(17, 'The harder you work for something, the greater you will feel when you achieve it.', 5, 5),
	(18, 'Push yourself, because no one else is going to do it for you.', 5, 9),
	(19, 'Dream it. Wish it. Do it.', 1, 1),
	(20, 'Sometimes we are tested not to show our weaknesses, but to discover our strengths.', 2, 13);
```

QuoteTags:
```sh
INSERT INTO public."QuoteTags" ("QuoteId", "TagId")
VALUES
	(1, 5),
	(1, 2),
	(2, 5),
	(2, 1),
	(3, 1),
	(3, 6),
	(4, 7),
	(4, 8),
	(5, 4),
	(5, 10),
	(6, 1),
	(6, 5),
	(7, 13),
	(7, 2),
	(8, 3),
	(8, 16),
	(9, 20),
	(9, 18),
	(10, 17),
	(10, 6),
	(11, 1),
	(12, 20),
	(13, 3),
	(14, 18),
	(15, 15),
	(16, 6),
	(17, 8),
	(18, 7),
	(19, 9),
	(20, 16);
```
