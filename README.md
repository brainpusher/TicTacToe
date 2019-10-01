# TicTacToe
Данный пример кода показывает реализацию, популярной в определенного рода кругах, игры крестики-нолики. Игра была реализована
мной на C# с видоизмененными правилами.
**Правила игры следующие:**
 - Игровое поле разделено на 9 полей, каждое из которых представляет собой мини-поле для классических крестиков-ноликов. 
   Таким образом имеем одно «большое поле» и 9 «маленьких полей»
 - Участники поочередно ставят крестики и нолики. Начинающий игру участник может походить в любое из 81 полей. 
 - Следующий участник имеет право ходить только в то маленькое поле (относительно большого), которое соответствует клетке,
   относительно маленького поля, в которую походил предыдущий участник
 - Чтобы выиграть в игре – участник должен выиграть три маленьких поля, стоящих по горизонтали, по диагонали или по вертикали
 - Если в маленьком поле образовалась ничья, то это поле считается ничейным
 - Если участник вынужден ходить в уже заполненное маленькое поле, то он вправе выбрать любое другое из свободных полей
 - После выигрыша маленького поля – оно не выходит из игры, пока в нем есть свободные клетки
