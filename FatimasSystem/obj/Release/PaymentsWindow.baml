   M S B A M L   `   `   `  ���� U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35[<clr-namespace:Microsoft.Windows.Controls;assembly=WpfToolkitMicrosoft.Windows.Controls   FatimasSystem"   FatimasSystem.PaymentsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     S
WpfToolkit<clr-namespace:Microsoft.Windows.Controls;assembly=WpfToolkit     -     �Name$  Window�� � Title$ Pagos��$��578.5��$	��306�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.��� -    �Name$ 
LayoutRoot��.+�)   #Microsoft.Windows.Controls.DataGrid  -     Name$ dgPagos��$   HorizontalScrollBarVisibility$ Hidden=�   SelectionMode$ Single=�   CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserResizeRows
 .     CanUserSortColumns .    AutoGenerateColumns .     RowHeaderWidth$ 17Q�   	RowHeight$ 25Q�$��19,14.5,0,0q�$��205.943��$	��Top=�$
��Left=�$��533.104��   
IsReadOnly . 
���   �$��13.333(�$��2q�
���   �   Columns 3   -Microsoft.Windows.Controls.DataGridTextColumn  -   
clmnId��/   )Microsoft.Windows.Controls.DataGridColumn   Header$ Número de pago��   Width8   2Microsoft.Windows.Controls.DataGridLengthConverter$	 .7* 4   .Microsoft.Windows.Controls.DataGridBoundColumn   Binding �� *	PaymentId+  -   
clmnAmount��$ Cantidad ($)��$ 1*  �� *Amount+  -   clmnDate��$ Fecha��$
 1.2*  �� *Date+�� -    ��Name$ btnAddPayment��$
��Left=�$��40��$��467.104,225.443,0,0q�$	��Top=�$��40�� � Cursor$
 Hand�� � ToolTip$ Agregar pago��.���� $��Images/add.png��$
��Fill=��� -   $ btnDeletePayment��$
��Left=�$��40��$��512.104,225.443,0,0q�$	��Top=�$��40��$
 Hand��$ Borrar pago��.���� $��Images/delete.png��$
��Fill=�� -	   $ InputBox��$y�	Collapsed=�.+�� 
���   � J� Opacity$	 0.5Q��� $	��250��
��� ���
���   �$��1q� �� CornerRadius$ 	0,55,0,55��$��Center=�$��Center=�._��� .+��� $��5q�$��
Input Box:��$
��Bold"�$��Cambria)��� -
    ��Name$ InputTextBox��$	��150��$��Center=�$��Center=���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $ 	YesButton��$��5q�$	��Yes����Z� �� -   $ NoButton��$��5q�$��No����Z� �� -   $ btnUpdatePayment��$
��Left=�$��40��$��422.104,225.443,0,0q�$	��Top=�$��40��$
 Hand��$ 
Actualizar��.���� -    ��Name$ imgUpdatePayment��$��Images/update_payment.png��$
��Fill=��� -    ��Name$ lblTotalCaption��$
��Left=�$��30��$��19,235.443,0,0q�$	��Top=�$��Total pagado:��$
��Bold"� �� Target ��  �� ElementName$ toDatePicker���� -   $ lblTotal��$
��Left=�$��30��$��105.823,235.443,0,0q�$	��Top=�$��$ 100�� �� $ toDatePicker��