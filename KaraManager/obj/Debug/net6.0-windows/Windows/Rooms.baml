   M S B A M L   `   `   `  ����F  BKaraManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KaraManagerKaraManager  5   	       KaraManager.Rooms   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KaraManager     5   	     � Title$  Rooms��5   	   $	��450��6   $	��800��6$    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� -   5        $��spRoom��5      
����ح� �� Orientation$ Vertical=�6;   $
��Left=�5   	   $	��400��6$   $��	0,2,0,215q�60   .+�5      �� $��Room Number��6   �� 5      -   5         ��Name$ 
txtRoomNum��5       �� TextWrapping$
 Wrap=�6*   $	��404��6>   $��28��6J   �� 5      $��Price Per Hour��6   �� 5      -   5        $ txtPricePerHour��5      $
 Wrap=�6/   $	��404��6C   $��28��6O   5      �� 5   
   $ 
Horizontal=�6   $
��Left=�5      $��10,10,0,-10q�68   .+�5      �� -   5         ��Name$ 	btnInsert��5      $��80��6)   $��Insert��64   $��21��5   5   �� 5      -   5        $ 	btnUpdate��5      $��10q�6)   $��80��65   $��Update��6A   $��21��5   5   �� 5      -   5        $ 	btnDelete��5      $��10q�6(   $��80��65   $��Delete��6@   $��21��5   5   �� 5      -   5        $ btnBack��5      $��Back to Menu��6&   $��80��6=   $��21��6H   6T   5      �� 5   
   -   5        $��lvRooms��5   '   $��
0,242,0,10q�6    �� View 5      �� 5      .P�5       �� $��	Room Name��6%    �� Width$	 100��68    �� DisplayMemberBinding 5!   %   �� 	 �� Path$
	 Name��� 5"      $��Price Per Hour��6%   $	 200��6=    5#   %   �� $	 Priceperhour�5$      5&      �� 5'   
   -	   5        $ btnReserveRoom��5'      $�� ��6)   $
��Left=�64   $��159,179,0,0q�6O   $	��Top=�6d   
 J� RenderTransformOrigin$
 
0.51,0.503&�6|   $��83��6�   $y�Hidden=�6�   6�   5(      5)      