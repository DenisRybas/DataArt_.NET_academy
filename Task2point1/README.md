Мои комментарии:\
При выполнении части 2 задания №1 выполняется JavaScript - код, 
при выполнении которого вылетает алерт. Происходит это из - за того, 
что в имени мы пишем этот скрипт и браузер распознаёт это не как имя человека,
а как JavaScript - код. Следовательно, нужно как - то говорить браузеру,
что это - имя человека, а не код. Я сделал это заменой символа на его entity 
в UTF-8 кодировке.