   M S B A M L   `   `   `  ����   FatimasSystem$    FatimasSystem.FindClientWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  -     �Name$  Window�� � Title$ Buscar cliente��$��990.3��$	��504�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.��� -    �Name$ 
LayoutRoot��.+�)  #Microsoft.Windows.Controls.DataGrid  -     Name$ dgGuests��$   HorizontalScrollBarVisibility$ Hidden=�   SelectionMode$ Single=�   CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserResizeRows
 .     CanUserSortColumns .    AutoGenerateColumns .     RowHeaderWidth$ 17Q�   	RowHeight$ 25Q�$��
10,0,10,55q�   
IsReadOnly . 
���   �$��13.333(�$��2q�$	��225��$��Bottom=�
���   �   Columns 3  -Microsoft.Windows.Controls.DataGridTextColumn  -   
clmnId��/  )Microsoft.Windows.Controls.DataGridColumn   Header$ ID��   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$	 .8* 4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding �� *	IdGuest+  -   clmnName��$ Nombre��$ 2*  �� *Name+  -   clmnLastName��$ Apellido Paterno��$ 2*  �� *
LastName+  -   clmnSLastName��$ Apellido Materno��$ 2*  �� *	SLastName+  -   clmnCountry��$ País��$
 1.2*  �� *	Country+  -	   	clmnState��$ Estado��$
 1.5*  �� *State+  -
   clmnCity��$ Ciudad��$
 1.5*  �� *City+  -   clmnTelephone��$ 	Teléfono��$
 1.7*  �� *	Telephone+  -   	clmnEmail��$ Email��$
 1.2*  �� *Email+  -   clmnAddress��$ 
Dirección��$
 1.2*  �� *	Address+�� -    ��Name$ btnSelectClient��$��Seleccionar cliente��$��0,0,81.333,10q� � Cursor$
 Hand��$��Right=�$	��118��$��26��$��Bottom=��� -   $ 	btnCancel��$��Cancelar��$��	0,0,10,10q�$
 Hand��$��Right=�$��66.333��$��26��$��Bottom=��� -    ��Name$ lblCurp��$
��Left=�$��30��$��104.5,11.5,0,0q�$	��Top=� �� Target ��  �� ElementName$ txtCurp��.���� $��_CURP o ID del cliente:���� -   $ btnFindClient��$��50��$��0,77,61.833,0q�$	��Top=�$��1��$
 Hand�� � ToolTip$ Buscar clientes��$��Right=�$��50��.���� -    ��Name$ imgFindClient��$��Images/find-user-icon.png��$
��Fill=��� -   $ lblName��$
��Left=�$��30��$��173.023,46.5,0,0q�$	��Top=� �� $ txtName��.���� $��_Nombre:���� -   $ lblLastName��$
��Left=�$��30��$��128.203,81.5,0,0q�$	��Top=� �� $ txtLastName��.���� $��_Apellido paterno:���� -   $ lblSLastName��$
��Left=�$��30��$��124.919,116.5,0,0q�$	��Top=� �� $ txtSLastName��.���� $��Apellido _materno:��� -   $ gridTxts��$��139.973,10,81.333,285q�.+��� -    ��Name$ txtCurp��$
��Left=�$��30�� �� TextWrapping$
 Wrap=�$	��Top=�$	��150�� �� 	MaxLength$ 20��
 � Tag$ 	CURP o ID��$��0��$��100.5,0,0,0q��� -   $ txtName��$
��Left=�$��30��$��100.5,35,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtLastName��$
��Left=�$��30��$��100.5,70,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtSLastName��$
��Left=�$��30��$��100.5,105,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtState��$
��Left=�$��30��$��449.194,0,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtCity��$
��Left=�$��30��$��449.194,35,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtTelephone��$
��Left=�$��30��$��449.194,70,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -   $ txtEmail��$
��Left=�$��30��$��449.194,105,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 20��$ 	CURP o ID��$��0���� -    ��Name$ comboCountry��$
��Left=�$��30��$��100.503,140,0,0q�$	��Top=�$	��150��$��4���� -    $ 
txtAddress��$
��Left=�$��30��$��449.194,140,0,0q�$
 Wrap=�$	��Top=�$	��150��$ 50��$��8���� -!   $ 	lblEstado��$
��Left=�$��30��$��533.133,11.5,0,0q�$	��Top=� �� $ txtState��.���� $��_Estado:���� -"   $ lblCity��$
��Left=�$��30��$��533.133,46.5,0,0q�$	��Top=� �� $ txtCity��.���� $��C_iudad:���� -#   $ lblTelephone��$
��Left=�$��30��$��522.213,81.5,0,0q�$	��Top=� �� $ txtTelephone��.���� $��_Teléfono:���� -$   $ lblEmail��$
��Left=�$��30��$��540.239,116.5,0,0q�$	��Top=� �� $ txtEmail��.���� $��Emai_l:���� -%   $ 
lblCountry��$
��Left=�$��30��$��196.049,151.5,0,0q�$	��Top=� �� $ comboCountry��.���� $��_País:���� -&   $ btnAddClient��$��	10,0,0,10q�$
 Hand��$��40��$��Bottom=�$ Agregar un cliente��$
��Left=�$��40��.���� -'   $ imgAddClient��$��Images/add_user.png��$
��Fill=��� -(   $ btnDeleteClient��$��	55,0,0,10q�$
 Hand��$��40��$��Bottom=�$ Eliminar cliente��$
��Left=�$��40��.���� -)   $ imgDeleteClient��$��Images/remove_user.png��$
��Fill=��� -*   $ 
lblAddress��$
��Left=�$��30��$��518.983,151.5,0,0q�$	��Top=� �� $ 
txtAddress��.���� $��_Dirección:��