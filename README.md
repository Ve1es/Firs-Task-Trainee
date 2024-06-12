# SubwaySerfClone
Проект представляет собой бесконечный раннер с элементами регистрации, авторизации и игрового процесса, схожего с игрой "Subway Surf".

## Регистрация
При первом запуске игры пользователю необходимо заполнить форму для регистрации, включающую следующие поля:

- Email
- Имя
- Пароль
- Повтор пароля

После успешной регистрации игрок перенаправляется в "Главное меню".

## Авторизация
Если игрок вышел из аккаунта, при следующем входе в игру необходимо заполнить данные для авторизации:

- Email
- Пароль

После успешного входа игрок перенаправляется в "Главное меню". Если игрок просто закрыл приложение, при следующем запуске осуществляется "тихая" авторизация.

## Главное меню
Главное меню включает:

- Модель аватара и готовую локацию
- Кнопку для начала игры
- Кнопку для выхода из игры
- Кнопку для выхода из аккаунта

## Игровой процесс
Игровой процесс представляет собой бесконечный бег с препятствиями:

- Аватар игрока бежит 4 секунды по дороге, после чего начинают появляться препятствия.
- Игрок должен избегать препятствий (свайпы влево, вправо, вверх для прыжка, вниз для подката).
- Если игрок не успевает увернуться, проигрывается анимация смерти и появляется надпись "Game Over".
- Скорость аватара постепенно увеличивается.

## Реализованные требования
Использование Dotween для анимации надписи "Game Over":
В проекте применен Dotween для создания плавной и привлекательной анимации появления надписи "Game Over" после смерти аватара.

- Создание локации для спавна препятствий с возможностью увернуться от них.
Реализована локация, где генерируются препятствия, от которых игрок может увернуться, используя свайпы для изменения направления движения аватара.

- Использование пула объектов для генерации препятствий.
Применен пул объектов для эффективного и оптимального создания препятствий на пути аватара, что улучшает производительность игры.

- Создание управления для тестирования в редакторе.
Добавлено управление, позволяющее тестировать игровые механики и взаимодействия непосредственно в редакторе Unity.

- Добавление рекламы с вознаграждением (SDK AdMob).
Интегрирован SDK AdMob, позволяющий игроку продолжить игру после просмотра рекламы с вознаграждением.

- Реализация лидерборда.
Лидерборд реализован для отслеживания и отображения лучших результатов игроков, мотивируя их улучшать свои показатели.

- Использование сервиса Firebase для регистрации, логина и лидерборда.
В проекте применены сервисы Firebase для реализации функционала регистрации, авторизации и управления лидербордом, обеспечивая надежное хранение и обработку данных пользователей.

## Технологии
- Unity
- C#
- Dotween
- Firebase
- AdMob SDK
