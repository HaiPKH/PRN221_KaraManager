   M S B A M L   `   `   `  ����F  BKaraManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KaraManager.WindowsKaraManager.Windows  5   	        KaraManager.Windows.Income   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KaraManager.Windows     5   	     � Title$  Income��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��147* �6   �� 5      $	��53* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ dpStartDate��5      $
��Left=�6*   $��
510,77,0,0q�6E   $	��Top=�6Y   $��2��6q     5   
   -   5        $ 	dpEndDate��5      $
��Left=�6(   $��	70,77,0,0q�6C   $	��Top=�6V   $��1��6n   �� 5   
   $
��From��6   $
��Left=�6   $��
542,51,0,0q�6:   $	��Top=�6N   $
��Bold"�6f   �� 5   
   $��To��6   $��Center=�6   $��0,51,0,0q�6:   $	��Top=�6L   $
��Bold"�6d   $��1��6v   �� 5   
   $��Select Time Range��6   
���  ��$
��Left=�6=   $��
580,33,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   $��2��6�   �� 5   
   $��Order by��6   
���  ��$
��Left=�64   $��
19,123,0,0q�6O   $	��Top=�6c   $
��Bold"�6{   $��1��6�   �� 5   
   -   5         ��Name$ cboOrder��5      $
��Left=�6%   $��562,154,0,0q�6@   $	��Top=�6U   $	��155��6m   $��2��6y   .@�5      �� $��Date Ascending��6   �� 5      $��Date Descending��6   �� 5      $��Revenue Ascending��6   �� 5      $��Revenue Descending��6   5      �� 5   
   $��Label��6   $
��Left=�6    $��-163,242,0,0q�6;   $	��Top=�6Q   �� 5   
   -   5        $��
lvInvoices��5   &   $��	0,0,241,0q�6    �� View 5      �� 5      .P�5      �� $��	Room Name��6%    �� Width$ 75��68    �� DisplayMemberBinding 5   %   ��  �� Path$ RoomName��� 5       $��Date Created��6%   $	 150��6;    5!   %   �� $ Datecreated� �� StringFormat$ d���� 5"      $��
Total Cost��6%   $	 100��69    5#   %   �� $ 	Totalcost�5$      5&      �� 5'   
   $��Total Income:��6   
���  ��$
��Left=�69   $��520,250,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   $��2��6�   �� 5(   
   -   5        	 ��Name$	 lbTotalIncome��5(      
���  ��$
��Left=�68   $��
37,250,0,0q�6S   $	��Top=�6g   $
��Bold"�6   $��1��6�   �� 5)   
   -   5        
 ��Name$
 btnLoad��5)      $��1��6"   $��View Income��62   $
��Left=�6H   $��
13,217,0,0q�6c   $	��Top=�6w   6�   �� 5*   
   -   5        $
 btnBack��5*      $��1��6"   $
��Back��62   $
��Left=�6A   $��
24,329,0,0q�6\   $	��Top=�6p   $��56��6�   6�   5+      5,      