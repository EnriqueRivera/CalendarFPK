   M S B A M L   `   `   `  ����  FatimasSystem$    FatimasSystem.FindClientWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  5      -   5          �Name$  Window��5       � Title$ Buscar cliente��5      $��990.3��5      $	��504��6    � WindowStyle$ 
ToolWindow=�6    � 
ResizeMode$ NoResize=�66   .��5
      � -   5         �Name$ 
LayoutRoot��5
      .+�5      )  #Microsoft.Windows.Controls.DataGrid  -   5          Name$ dgGuests��5      $   HorizontalScrollBarVisibility$ Hidden=�5         SelectionMode$ Single=�6+      CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserResizeRows
 .     CanUserSortColumns .    AutoGenerateColumns .     RowHeaderWidth$ 17Q�5         	RowHeight$ 25Q�6   $��
10,0,10,55q�6'      
IsReadOnly . 
���   �$��13.333(�5      $��2q�6)   $	��225��6=   $��Bottom=�6J   
���   �   Columns 5      3  -Microsoft.Windows.Controls.DataGridTextColumn  5      -   5        
clmnId��/  )Microsoft.Windows.Controls.DataGridColumn   Header$ ID��5         Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$	 .8* 6   4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding 5      �� *	IdGuest+  5      -   5        clmnName��$ Nombre��5      $ 2* 6    5      �� *Name+  5      -   5        clmnLastName��$ Apellido Paterno��5      $ 2* 6     5      �� *
LastName+  5      -   5        clmnSLastName��$ Apellido Materno��5      $ 2* 6     5      �� *	SLastName+  5       -   5        clmnCountry��$ País��5!      $
 1.2* 6    5"      �� *	Country+  5#      -	   5        	clmnState��$ Estado��5$      $
 1.5* 6    5%      �� *State+  5&      -
   5        clmnCity��$ Ciudad��5'      $
 1.5* 6    5(      �� *City+  5)      -   5        clmnTelephone��$ 	Teléfono��5*      $
 1.7* 6    5+      �� *	Telephone+  5,      -   5        	clmnEmail��$ Email��5-      $
 1.2* 6    5.      �� *Email+  5/      -   5        clmnAddress��$ 
Dirección��50      $
 1.2* 6    51      �� *	Address+53      �� 54      -   5         ��Name$ btnSelectClient��54      $��Seleccionar cliente��6$   $��0,0,81.333,10q�6B    � Cursor$
 Hand��6Y   $��Right=�6g   $	��118��6�   $��26��6�   $��Bottom=�6�   6�   �� 55      -   5        $ 	btnCancel��55      $��Cancelar��6   $��	0,0,10,10q�61   $
 Hand��6D   $��Right=�6R   $��66.333��6n   $��26��6}   $��Bottom=�6�   6�   �� 56      -   5         ��Name$ lblCurp��56   
   $
��Left=�6B   $��30��6]   $��104.5,11.5,0,0q�6i   $	��Top=�6�    �� Target 6   ��  �� ElementName$ txtCurp��.��6�   �� $��_CURP o ID del cliente:��6�   6�   �� 57      -   5        $ btnFindClient��57      $��50��6"   $��0,77,61.833,0q�6.   $	��Top=�6E   $��1��6]   $
 Hand��6j    � ToolTip$ Buscar clientes��6x   $��Right=�6�   $��50��6�   .��58      �� -   5         ��Name$ imgFindClient��58      $��Images/find-user-icon.png��6"   $
��Fill=�6E   59      �� 5:      -   5        $ lblName��5:   
   $
��Left=�6B   $��30��6]   $��173.023,46.5,0,0q�6i   $	��Top=�6�    6   �� $ txtName��.��6�   �� $��_Nombre:��6�   6�   �� 5;      -   5        $ lblLastName��5;   
   $
��Left=�6J   $��30��6e   $��128.203,81.5,0,0q�6q   $	��Top=�6�    6   �� $ txtLastName��.��6�   �� $��_Apellido paterno:��6�   6�   �� 5<      -   5        $ lblSLastName��5<   
   $
��Left=�6L   $��30��6g   $��124.919,116.5,0,0q�6s   $	��Top=�6�    6    �� $ txtSLastName��.��6�   �� $��Apellido _materno:��6�   6�   � 5=      -   5        $ gridTxts��5=   	   $��139.973,10,81.333,285q�6   .+�5>      �� -   5         ��Name$ txtCurp��5>      $
��Left=�6   $��30��69    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Y   $	��150��6q    �� 	MaxLength$ 20��6}   
 � Tag$ 	CURP o ID��6�   $��0��6�   $��100.5,0,0,0q�6�   �� 5?      -   5        $ txtName��5?      $
��Left=�6   $��30��69   $��100.5,35,0,0q�6E   $
 Wrap=�6[   $	��Top=�6o   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5@      -   5        $ txtLastName��5@      $
��Left=�6"   $��30��6=   $��100.5,70,0,0q�6I   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5A      -   5        $ txtSLastName��5A      $
��Left=�6#   $��30��6>   $��100.5,105,0,0q�6J   $
 Wrap=�6a   $	��Top=�6u   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5B      -   5        $ txtState��5B      $
��Left=�6   $��30��6:   $��449.194,0,0,0q�6F   $
 Wrap=�6]   $	��Top=�6q   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5C      -   5        $ txtCity��5C      $
��Left=�6   $��30��69   $��449.194,35,0,0q�6E   $
 Wrap=�6]   $	��Top=�6q   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5D      -   5        $ txtTelephone��5D      $
��Left=�6#   $��30��6>   $��449.194,70,0,0q�6J   $
 Wrap=�6b   $	��Top=�6v   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5E      -   5        $ txtEmail��5E      $
��Left=�6   $��30��6:   $��449.194,105,0,0q�6F   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   $ 20��6�   $ 	CURP o ID��6�   $��0��6�   �� 5F      -   5         ��Name$ comboCountry��5F      $
��Left=�6$   $��30��6?   $��100.503,140,0,0q�6K   $	��Top=�6d   $	��150��6|   $��4��6�   �� 5G      -    5        $ 
txtAddress��5G      $
��Left=�6!   $��30��6<   $��449.194,140,0,0q�6H   $
 Wrap=�6a   $	��Top=�6u   $	��150��6�   $ 50��6�   $��8��6�   5H      �� 5I      -!   5        $ 	lblEstado��5I   
   $
��Left=�6E   $��30��6`   $��533.133,11.5,0,0q�6l   $	��Top=�6�    6   �� $ txtState��.��6�   �� $��_Estado:��6�   6�   �� 5J      -"   5        $ lblCity��5J   
   $
��Left=�6B   $��30��6]   $��533.133,46.5,0,0q�6i   $	��Top=�6�    6   �� $ txtCity��.��6�   �� $��C_iudad:��6�   6�   �� 5K      -#   5        $ lblTelephone��5K   
   $
��Left=�6L   $��30��6g   $��522.213,81.5,0,0q�6s   $	��Top=�6�    6    �� $ txtTelephone��.��6�   �� $��_Teléfono:��6�   6�   �� 5L      -$   5        $ lblEmail��5L   
   $
��Left=�6D   $��30��6_   $��540.239,116.5,0,0q�6k   $	��Top=�6�    6   �� $ txtEmail��.��6�   �� $��Emai_l:��6�   6�   �� 5M      -%   5        $ 
lblCountry��5M   
   $
��Left=�6J   $��30��6e   $��196.049,151.5,0,0q�6q   $	��Top=�6�    6   �� $ comboCountry��.��6�   �� $��_País:��6�   6�   �� 5N      -&   5        $ btnAddClient��5N      $��	10,0,0,10q�6!   $
 Hand��64   $��40��6B   $��Bottom=�6N   $ Agregar un cliente��6i   $
��Left=�6�   $��40��6�   .��5O      �� -'   5        $ imgAddClient��5O      $��Images/add_user.png��6!   $
��Fill=�6>   5P      �� 5Q      -(   5        $ btnDeleteClient��5Q      $��	55,0,0,10q�6$   $
 Hand��67   $��40��6E   $��Bottom=�6Q   $ Eliminar cliente��6l   $
��Left=�6�   $��40��6�   .��5R      �� -)   5        $ imgDeleteClient��5R      $��Images/remove_user.png��6$   $
��Fill=�6D   5S      �� 5T      -*   5        $ 
lblAddress��5T   
   $
��Left=�6H   $��30��6c   $��518.983,151.5,0,0q�6o   $	��Top=�6�    6   �� $ 
txtAddress��.��6�   �� $��_Dirección:��6�   6�   5U      5V      