   M S B A M L   `   `   `  ����F  BKaraManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KaraManager.WindowsKaraManager.Windows  5   	   &     KaraManager.Windows.AdminMessage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KaraManager.Windows     5   	     � Title$  AdminMessage��5   	   $	��450��6   $	��860��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��49* �6   �� 5      $	��31* �6   .+�5   
   �� -   5         ��Name$ lvRooms��5      $��	0,0,246,0q�6$    �� View 5      �� 5      .P�5      �� $��Rooms��6%    �� Width$	 240��64    �� DisplayMemberBinding 5   %   ��  �� Path$
 Name�5      5      �� 5   
   -   5        $ 
lvMessages��5      $��
280,0,0,81q�6'   $��2��6;    5      �� 5      .P�5      �� $��	Time Sent��6%   $	 130��68    5   %   �� $ Timesent��� 5      $��Sender��6%   $	 100��65    5   %   �� $ 
Sendername��� 5      $��Content��6%   $	 350��66    5   %   �� $ Content�5      5!      �� 5"   
   -   5         ��Name$ 
txtMessage��5"      $
��Left=�6'   $��280,368,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��439��6�   $��20��6�   $��2��6�   �� 5#   
   -   5        	 ��Name$	 btnSend��5#      $
��Send��6$   $
��Left=�63   $��205,368,0,0q�6N   $	��Top=�6c   $��51��6{   $��20��6�   $��1��6�   �� 5$   
   -   5        $	 btnBack��5$      $
��Back��6"   $
��Left=�61   $��	8,393,0,0q�6L   $	��Top=�6_   $��66��6w   $��1��6�   �� 5%   
   -   5        $	 	btnDelete��5%      $��Delete��6&   $
��Left=�67   $��277,368,0,0q�6R   $	��Top=�6g   $��41��6   $��1��6�   5&      5'      