﻿let page = document.querySelector('.page');
let themeButton = document.querySelector('.theme-button');

const currentTheme = localStorage.getItem("theme");
// Если текущая тема в localStorage равна "dark"…
if (currentTheme == "dark") {
    // …тогда мы используем класс .dark-theme
    document.body.classList.add("dark-theme");
}

// Отслеживаем щелчок по кнопке
themeButton.addEventListener("click", function () {
    // Переключаем класс .dark-theme при каждом щелчке
    document.body.classList.toggle("dark-theme");
    // Допустим, тема светлая
    let theme = "light";
    // Если <body> содержит класс .dark-theme…
    if (document.body.classList.contains("dark-theme")) {
        // …тогда делаем тему тёмной
        theme = "dark";
    }
    // После чего сохраняем выбор в localStorage
    localStorage.setItem("theme", theme);
});