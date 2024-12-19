# Взаимосвязь открытых систем

Этот репозиторий содержит лабораторные работы по курсу в МИФИ, посвящённому модели OSI

В рамках курса необходимо составить 4 лабораторные работы, относящиеся, соответственно, к транспортному уровню, сеансовому уровню, уровню представления и прикладному уровню. Лабораторные работы реализуются в программе NetLab.exe, написанной на C#.

Лабораторные работы представляют собой специальные файлы с расширением .lab. Файлы открываются только той версией программы, в которой были созданы. В этом же репозитории вместо файлов .lab будут использоваться текстовые файлы в формате Markdown, так что работы останутся актуальными в будущем и к ним можно будет писать пояснения.

Похоже, что при приёмке лабораторной работы она сравнивается с имеющимися путём подсчёта числа использований разных операций. Для успешной сдачи следует не только поменять названия переменных, но и добавить/удалить какие-то операции. Также в файле лабораторной работы фиксируются количество запусков и количество изменений.

Для каждого варианта лабораторной работы используется свой синтаксис и условия. Синтаксисов всего 10 каждый год, но некоторые из них могут совпадать. Например, в версии 2024 года совпадают варианты синтаксиса 1, 9 и 10 и варианты синтаксиса 5, 6 и 7. Синтаксисы будут обозначаться как STX1, STX2 и т.д., в порядке добавления в репозиторий.

Дистрибутив можнно найти в папке programs.

## Источники

- https://github.com/hilleri123/KeFear
- https://disk.yandex.ru/d/qXyEjbwjFxdRaw
- https://gitlab.com/SBloatedCat2/osi-netlab-186

## Формат текстового файла лабораторной работы

Используется Markdown. В начале указывается используемый синтаксис (целиком или только код синтаксиса, например, STD). Код помещается в секции кода, а перед кодом указывается, обработчик какого события представлен (для этого можно использовать заголовки). Так же можно добавлять пояснения к коду, они могут быть внутри секций кода в виде комментариев или в виде текста вне секций кода.


## Формат файла .lab лабораторной работы

На самом деле это ZIP файл с паролем, в котором содержится единственный файл 1.txt, в котором в некотором текстовом формате записана лабораторная работа.

Пароль от ZIP файла меняется от года к году. В 2024 это Ne1t45_L7a&nv, в 2021 году это Ne1t45_L7a&ol

Файлы с расширением .dsc тоже являются ZIP файлами с таким же паролем

Теперь как этот пароль зашит в программу. Если декомпилировать программу и исследовать её код, можно заметить места сохранения и распаковки ZIP файлов. В таких местах подставляется значение пароля, получаемое как примерно такая строка

```
Encoding.Unicode.GetString(Resources.vibration1.GetPropertyItem(40093).Value, 0, 22) + "nv"
```

Получается, есть какой-то ресурс vibration1, у которого нужно получить какое-то свойство 40093, взять префикс длиной 22 и добавить к нему суффикс "nv".

Далее если поискать в ресурсах этого exe подстроку vibration1, то там будет такое

```
<data name="vibration1" mimetype="application/x-microsoft.net.object.binary.base64">
  <value>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</value>
</data>
```

Собственно, это некоторое значение, закодированное в base64. Если декодировать и посмотреть, что получилось, то покажутся бинарные данные, среди которых есть текстовые строки. Далее можно попробовать подставить разные строки и посмотреть, что получится. Все эти не подходят, некоторые даже значительно короче, чем нужно, например, Ne1t45_L7a&c, так что смотрим дальше. (Спойлер: это правильная строка, потому что закодирована в UCS2, где на символ приходится 2 байта, так что в байта её длина 24 и от неё отщипывается последний символ длиной 2). 

Если погуглить число 40093, то можно обнаружить его среди [тегов EXIF](https://exiv2.org/tags.html). EXIF - это стандарт того, как в картинку зашить дополнительную информацию.

> 0x9c9d - 40093 - XPAuthor - Author tag used by Windows, encoded in UCS2

Если взглянуть ещё раз на подстроки, то среди них имеются JFIF и Exif. Если поискать  в Интернете информацию по строке JFIF, то можно узнать, что это маркер формата JPEG. Картинка JPEG начинается с байтов FF D8 и заканчивается байтами FF D9, так что можно найти в декодированных байтах именно такую подпоследовательность байт FF D8 ... FF D9, она всего одна. Если её сохранить в файл, то он будет корректным. Просмотрщики  EXIF позволят увидеть все EXIF теги, в том числе тег XPAuthor со значением Ne1t45_L7a&c

Остаётся отщипнуть последний символ, добавить два нужных символа и проверить, что архив открывается. С учётом того, что за несколько лет содержимое vibration1 не поменялось, полагаю, что и в будущем не поменяется, так что можно брутфорсом определить нужный суффикс из двух символов и не заниматься анализом декомпилированного кода.

Кстати, в ресурсах есть и Password, но он неправильный
```
  <data name="Password" xml:space="preserve">
    <value>SuperPassword123</value>
  </data>
```

Также в файле лабораторной фиксируются все редактирования и количество запусков.

## Административный режим

В программе можно есть административный режим, в котором можно редактировать код верхних уровней, например, добавлять туда логирование. Не знаю, насколько это полезно, подробно не исследовал. Включить этот режим можно только введя какой-то пароль, поле ввода открывается через меню "Параметры". В исходном коде пароля нет, естть только соль, хеш и алгоритм. Взломать у меня его не получилось, но зато получилось отредактировать в dnSpy строчку, его взламывающую. Желающим следует искать функции SequenceEqual или Rfc2898DeriveBytes в исходном коде и отредактировать IL инструкции, например, поменять optcode brfalse на brtrue у иструкции в условии, чтобы под "пароль" подходила любая строка.

## Спецсимволы ASCII

NUL - 0
SOH - 1
STX - 2
ETX - 3
EOT - 4
ENQ - 5
ACK - 6
BEL - 7
