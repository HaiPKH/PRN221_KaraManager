   M S B A M L   `   `   `  ����F  BKaraManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KaraManagerKaraManager  5   	       KaraManager.Invoices   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KaraManager     5   	     � Title$  Invoices��5   	   $	��709��6   $	��962��6'    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��557* �6   �� 5      $	��15* �6   �� 5      $
��283* �6   .+�5   
   �� -   5        $��spRoom��5      
����ح� �� Orientation$ Vertical=�6;   $
��Left=�5   	   $	��400��6$   $��	0,2,0,215q�60   .+�5      �� $��Room Number��6   �� 5      -   5         ��Name$ 
txtRoomNum��5       �� TextWrapping$
 Wrap=�6*   $	��404��6>   $��28��6J    �� 
IsReadOnly$
 True��6V   �� 5      $��Date Created��6   �� 5      -   5        $ txtDateCreated��5      $
 Wrap=�6.   $	��404��6B   $��28��6N   $
 True��6Z   �� 5      $��Time Started��6   �� 5      -   5        $ txtTimestarted��5      $
 Wrap=�6.   $	��404��6B   $��28��6N   $
 True��6Z   �� 5      $��
Time Ended��6   �� 5      -   5        $ txtTimeended��5      $
 Wrap=�6,   $	��404��6@   $��28��6L   $
 True��6X   �� 5      $��Time Elapsed��6   �� 5      -   5        $ txtTimeelapsed��5      $
 Wrap=�6.   $	��404��6B   $��28��6N   $
 True��6Z   �� 5      $��Other costs��6   �� 5      -   5        $ txtOthercost��5      $
 Wrap=�6,   $	��404��6@   $��28��6L   6X   �� 5      $��
Total cost��6   �� 5      -   5        $ txtTotalcost��5      $
 Wrap=�6,   $	��404��6@   $��28��6L   $
 True��6X   5"      �� 5#   
   $ 
Horizontal=�6   $
��Left=�5$      $��10,347,0,240q�68   $	��390��6N   .+�5%      �� -	   5         ��Name$ 	btnUpdate��5%      $��80��6(   $��Update��64   $��21��5&   5   $��10,5,5,0q�6A   �� 5'      -
   5        $ 	btnDelete��5'      $��80��6)   $��Delete��64   $��21��5(   5   $��5,5,5,0q�6A   �� 5)      -   5        $ btnBack��5)      $��Back to Menu��6&   $��80��6=   $��21��6H   $��5,5,5,0q�6T   5*      �� 5+      -   5        $ 
btnRefresh��5+      $��Refresh��6)   $��80��6;   $��21��6F   $��5,5,5,0q�6R   5,      5-      �� 5.   
   -   5        $��
lvInvoices��5.   '   $��
0,426,0,10q�6   $��3��69    �� View 5/      �� 50      .P�51      �� $��	Room Name��6%   	 �� Width$	 75��68   
 �� DisplayMemberBinding
 52   %   ��  �� Path$ RoomName��� 53      $��Date Created��6%   $		 150��6;   
 54   %   �� $ Datecreated��� 55      $��Time Started��6%   $		 150��6;   
 56   %   �� $ Timestarted��� 57      $��
Time Ended��6%   $		 150��69   
 58   %   �� $ 	Timeended��� 59      $��Time Elapsed��6%   $		 150��6;   
 5:   %   �� $ Timeelapsed��� 5;      $��Other Costs��6%   $		 150��6:   
 5<   %   �� $ 	Othercost��� 5=      $��
Total Cost��6%   $		 100��69   
 5>   %   �� $ 	Totalcost�5?      5A      �� 5B   
   $��2��6   $��Showing��6    $
��Left=�62   $��
35,383,0,0q�6M   $	��Top=�6a    J� RenderTransformOrigin$ 
0.55,0.549&�6y   �� 5C   
   -   5        $ txtRecordsNum��5C      $��2��6)   $
��Left=�69   $��
96,387,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5D   
   $��2��6   $��Records��6    $
��Left=�62   $��221,383,0,0q�6M   $	��Top=�6b   5E      5F      