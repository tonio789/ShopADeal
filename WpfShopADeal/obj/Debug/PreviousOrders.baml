   M S B A M L   `   `   `  ����G  CWpfShopADeal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfShopADealWpfShopADeal  5   	   !    WpfShopADeal.PreviousOrders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfShopADeal     5   	     � Title$  PreviousOrders��5   	   $	��450��6    $	��800��6-    � 	Resources 5	         	LetrStyle �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property	 P� Value��%  &	        �� 5
   
   " ��6"   .�5      ��  � ��# � ��6+   �� 5       � ��
 ���� 6+   �� 5       � ��$ 5q�6(   �� 5       � ��$
 Left=�6;   �� 5       � ��$	 Top=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w    . $��0,0,0,0q�6�   ._�5      �� #��z��6/   ��. # z 6�   #��z��6�   5       5      P� 5       � {�	 .  . �5   "   �� # � ��6?    � ��5      5      5      5      5      .��5       � .+�5!   
   � 
 � RowDefinitions
 5"      �� 5#      $��45 �6    6.   �� 5$      6"   .+�5&      �� $��0��6   
�������6"   �� 5'      ���	#FF5271FF$��0,42,0,3q�6,   $��2��6>   �� 5(      -   5         ��Name$
 Logo��5(   !   $��0��6   $
��Left=�6/   $��Center=�6J   $��14��6f   $��93��6s   $7��1/WhatsApp Image 2022-10-14 at 8.14.27 PM (1).jpeg��6~   $��10,0,0,0q�6�   �� 5)      -   5         ��Name$ 
btn_inicio��5)      $��INICIO��6)   $
��Left=�6:   $��Center=�6U   $��	Quicksand)�6�   $��18��6�   $��70��6�   $��9(�6�   ���	#FF5271FF$
��Bold"�6�   $��	140,0,0,0q�6  ��6p   Z� ��6�   Z� 6  �� 5*      -   5        $ btn_comprar��5*      $��COMPRAR��6*   $
��Left=�6<   $��Center=�6W   $��	Quicksand)�6�   $��18��6�   $��70��6�   $��9(�6�   ���	#FF5271FF$
��Bold"�6�   $��	210,0,0,0q�6  ��6r   Z� ��6�   Z� 6  �� 5+      -   5        $ btn_tiendas��5+      $��MIS TIENDAS��6*   $
��Left=�6@   $��Center=�6[   $��	Quicksand)�6�   $��18��6�   $��70��6�   $��9(�6�   ���	#FF5271FF$
��Bold"�6�   $��	280,0,0,0q�6  ��6v   Z� ��6�   Z� 6  �� 5,      -   5        $ btn_categorias��5,      $��
CATEGORIAS��6-   $
��Left=�6B   $��Center=�6]   $��	Quicksand)�6�   $��18��6�   $��70��6�   $��9(�6�   ���	#FF5271FF$
��Bold"�6�   $��	350,0,0,0q�6	  ��6x   Z� ��6�   Z� 6  �� 5-      -   5        $ btn_user��5-   "   $��0��6   $��
BIENVENIDO��64   $��Right=�6I   $��45��6e   $	��Top=�6q   $	��132��6�   
����������	#FF5271FF���	#FFD8D8D8$��Quicksand Light)�6�   �� 5.      -   5        $ btn_cart��5.   f   $��0��6   $��25��6x   $��25��6�   $
��Left=�6�   $��Center=�6�   $��	628,0,0,0q�6�   ��6#   Z� ��69   Z� ��6P   Z� .��50      �� $��Right=�6   $��25��64   $��25��6?   $��Center=�6K   $��/shopping-cart.png��6f    J� RenderTransformOrigin$ 0.565,0.479&�6�   52      � 53      $��1��6    � ColumnDefinitions 54      �� 55      6)   �� 56      $	��650 �6'   65   �� 57      6)   
 59      �� 5:      $��50 �6$   62   �� 5;      6&   �� 5<      $��50 �6$   62   .+�5>      �� $��0��6   $��1��6%   #���   65   $��SUS COMPRAS��6Y   $
��Left=�6o   $��Bottom=�6�   $��Quicksand Medium)�6�   $	��150��6�   
�������$��20(�6�   ��6�   Z� 6�   &   System.Windows.Controls.DataGrid  5@      -   5        $��DG��5@      $��1��6%   $��1��62   $��	Quicksand)�6B      AutoGenerateColumns .     
IsReadOnly .    Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6-      Header$ Pedido��68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *
idPedido+6i     5C      $	 210 6-   $ 	Artículo��69    6K   �� *nombre+6h     5D      $ 70 6-   $ Cantidad��68    6J   �� *
cantidad+6i     5E      $ 70 6-   $ Precio��68    6I   �� *precio+6f     5F      $ 70 6-   $ Calificación��68    6N   �� *calificacion+6q   4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ 1��61   $ 30 6=      CellTemplate 5I      �� 5J   "   .R�5K   &   �� .+�5L   *   �� -	   5        $��+��5L   `   $��Right=�6l   $��Bottom=�6�   $��16��6�   $��	Quicksand)�6�   $��15��6�   $��Center=�6�   $	��Top=�6�   $��8(�6  ���	#FFF5C418
�������$��0,0,5,5q�6b  ��61   �� *idArticuloPedido+��68  Z� 6s  5M   '   5N   #   5P        5R      $ 2��61   $ 30 6=    5S      �� 5T   "   .R�5U   &   �� .+�5V   *   �� -
   5        $��+��5V   a   $��Right=�6m   $��Bottom=�6�   $��16��6�   $��	Quicksand)�6�   $��15��6�   $��Center=�6�   $	��Top=�6�   $��8(�6  ���	#FFF5C418
�������$��0,0,5,5q�6c  ��61   �� *idArticuloPedido+��69  Z� 6t  5W   '   5X   #   5Z        5\      $ 3��62   $ 30 6>    5]      �� 5^   "   .R�5_   &   �� .+�5`   *   �� -   5        $��+��5`   a   $��Right=�6m   $��Bottom=�6�   $��16��6�   $��	Quicksand)�6�   $��15��6�   $��Center=�6�   $	��Top=�6�   $��8(�6  ���	#FFF5C418
�������$��0,0,5,5q�6c  ��61   �� *idArticuloPedido+��69  Z� 6t  5a   '   5b   #   5d        5f      $ 4��61   $ 30 6=    5g      �� 5h   "   .R�5i   &   �� .+�5j   *   �� -   5        $��+��5j   a   $��Right=�6m   $��Bottom=�6�   $��16��6�   $��	Quicksand)�6�   $��15��6�   $��Center=�6�   $	��Top=�6�   $��8(�6  ���	#FFF5C418
�������$��0,0,5,5q�6c  ��61   �� *idArticuloPedido+��69  Z� 6t  5k   '   5l   #   5n        5p      $ 5��61   $ 30 6=    5q      �� 5r   "   .R�5s   &   �� .+�5t   *   �� -   5        $��+��5t   `   $��Right=�6l   $��Bottom=�6�   $��16��6�   $��	Quicksand)�6�   $��15��6�   $��Center=�6�   $	��Top=�6�   $��8(�6  ���	#FFF5C418
�������$��0,0,5,5q�6b  ��61   �� *idArticuloPedido+��68  Z� 6s  5u   '   5v   #   5x      5|      5      5�      5�      5�      