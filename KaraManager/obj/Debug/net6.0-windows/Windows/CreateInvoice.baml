   M S B A M L   `   `   `  ����F  BKaraManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KaraManagerKaraManager  5   	       KaraManager.CreateInvoice   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KaraManager     5   	     � Title$  Create Invoice��5   	   $	��359��6    $	��348��6-    � 
ResizeMode$ NoResize=�5	   	   .��5
      � $��Center=�6   $	��348��6(   $	��344��64   $	��Top=�6A   .+�5   
   �� $��Time Started:��6   $
��Left=�6(   $��	39,90,0,0q�6C   $	��Top=�6V   �� 5   
   -   5         ��Name$ lbTimeStarted��5      $�� ��6'   $
��Left=�62   $��
182,90,0,0q�6M   $	��Top=�6a   $��96��6y   �� 5   
   $��Date Created: ��6   $
��Left=�6)   $��	39,44,0,0q�6D   $	��Top=�6W   �� 5   
   -   5        $ lbDateCreated��5      $�� ��6'   $
��Left=�62   $��
182,44,0,0q�6M   $	��Top=�6a   $��96��6y   �� 5   
   $��Time Ended:��6   $
��Left=�6&   $��
39,130,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ lbTimeEnded��5      $�� ��6%   $
��Left=�60   $��182,130,0,0q�6K   $	��Top=�6`   $��96��6x   �� 5   
   $��Time Elapsed:��6   $
��Left=�6(   $��
39,171,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ lbTimeElapsed��5      $�� ��6'   $
��Left=�62   $��182,171,0,0q�6M   $	��Top=�6b   $��96��6z   �� 5   
   $��Other costs:��6   $
��Left=�6'   $��
39,212,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$ txtOtherCost��5      $
��Left=�6(   $��182,216,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��120��6�   6�   �� 5   
   $��
Total Cost��6   $
��Left=�6%   $��
39,243,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   $��Italic$�6~   �� 5   
   -   5        $ lbTotalCost��5      $�� ��6%   $
��Left=�60   $��182,243,0,0q�6K   $	��Top=�6`   $
��Bold"�6x   $��Italic$�6�   $	��120��6�   �� 5   
   -   5         ��Name$ btnCreateInvoice��5      $��Confirm��6+   $��Center=�6=   $��	0,279,0,0q�6Z   $	��Top=�6m   $��83��6�   6�   �� 5   
   -   5        $ 
lbRoomName��5      $��Room ��6$   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $
��Bold"�6z   $��72��6�   �� 5   
   -	   5        $ lbPricePerHour��5      $�� ��6(   $
��Left=�63   $��
192,10,0,0q�6N   $	��Top=�6b   $��96��6z   �� 5   
   -
   5        $ txtRid��5      $�� ��6    $
��Left=�6+   $��
136,10,0,0q�6F   $	��Top=�6Z   $y�Hidden=�6r   5      5      