   M S B A M L   `   `   `  ����C  ?NoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NoteBookNoteBook  5   	       NoteBook.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NoteBook     5   	     � Title$  Carnet de notes��5   	   $	��450��6!   $	��800��6.   .��5	      � -   5         �Name$ 
mainWindow��5	      $��50q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ 
examButton��5   $   $��Rentrer un examen��68   $��2��6T   $��18(�6a   $
��Bold"�6o   �� 5   
   -   5        $ matiereButton��5      $��Saisir les matières��6(   $
��Bold"�6F   $��0��6l   $��18(�6y   �� 5   
   -   5        $ moyenneButton��5       $��Afficher les moyennes��67   $��4��6W   $
��Bold"�6d   $��18(�6v   �� 5   
   -   5         ��Name$ notebookPicture��5      $��notebook.jpg��6)   $��1��6?   $��1��6O   $��3��6\   5      5      