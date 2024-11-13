# Cross Platform  
# Module #1
# Anastasiia Levchenko IPZ 32

## INSTRUCTIONS

## Кроки для завантаження та запуску коду
### Запускаєтья Код з вирішенням задачі і тести
Виконайте наступні кроки для завантаження репозиторію та запуску проекту:
1. Завантажте репозиторій у вигляді ZIP файлу з GitHub.
2. Відкрийте термінал Developer PowerShell for VS 2022.
3. Перейдіть до директорії проекту:  
   `cd path/to/extracted-repo`
4. Білд:
   ```bash
   dotnet build Build.proj -t:Build
   ```
5. Запуск вирішення задачі:  
   ```bash
   dotnet build Build.proj -t:Run
   ```
6. Тестування результатів вирішення задачі:
   ```bash
   dotnet build Build.proj -t:Test
   ```
