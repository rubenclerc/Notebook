   M S B A M L   `   `   `  ����C  ?NoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NoteBookNoteBook  5   	       NoteBook.EditExamWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NoteBook     5   	     � Title$  Create an exam��5   	   $	��450��6    $	��800��6-   .��5	      � $��15q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6    � ColumnDefinitions 5"   
   �� 5#      $��* �6   �� 5$      $��10 �6   �� 5%      $��* �6   .+�5(   
   �� $��Module��6   $��0��6!   $��0��6.   $��Center=�6>   �� 5)   
   -   5         ��Name$ modules��5)      $��0��6$   $��2��61   �� 5+   
   $
��Date��6   $��2��6   $��0��6,   $��Center=�6<   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$
 date��5,      $��2��6#   $��2��63   $��Center=�6@   $��Stretch=�6[   �� 5.   
   $��Teacher��6   $��4��6"   $��0��6/   $��Center=�6?   �� 5/   
   -   5         ��Name$ teacher��5/      $��4��6#   $��2��60   �� 51   
   $��Score��6   $��6��6    $��0��6-   $��Center=�6=   �� 52   
   -   5        $ score��52      $��6��6!   $��2��6.   �� 54   
   -   5         ��Name$ absentCheckbox��54      $��Absent��6+   $��8��6<   $��0��6I   $��3��6Y   $��Center=�6m   �� 56   
   -   5         ��Name$ validateButton��56   "   $��Validate��6:   $��10��6M   $��0��6[   �� 57   
   -   5        $ cancelButton��57       $��Cancel��66   $��2��6G   $��10��6W   59      5:      