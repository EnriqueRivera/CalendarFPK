   M S B A M L   `   `   `  ����U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35[<clr-namespace:Microsoft.Windows.Controls;assembly=WpfToolkitMicrosoft.Windows.Controls  5       FatimasSystem"   FatimasSystem.PaymentsWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      S
WpfToolkit<clr-namespace:Microsoft.Windows.Controls;assembly=WpfToolkit     5      -   5          �Name$  Window��5       � Title$ Pagos��5      $��578.5��5      $	��306��6    � WindowStyle$ 
ToolWindow=�6    � 
ResizeMode$ NoResize=�6M   .��5
      � -   5         �Name$ 
LayoutRoot��5
      .+�5      )   #Microsoft.Windows.Controls.DataGrid  -   5          Name$ dgPagos��5      $   HorizontalScrollBarVisibility$ Hidden=�5         SelectionMode$ Single=�6+      CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserResizeRows
 .     CanUserSortColumns .    AutoGenerateColumns .     RowHeaderWidth$ 17Q�5         	RowHeight$ 25Q�6   $��19,14.5,0,0q�6'   $��205.943��5      $	��Top=�6   $
��Left=�5      $��533.104��6      
IsReadOnly . 
���   �$��13.333(�5      $��2q�6)   
���   �   Columns 5      3   -Microsoft.Windows.Controls.DataGridTextColumn  5      -   5        
clmnId��/   )Microsoft.Windows.Controls.DataGridColumn   Header$ Número de pago��5         Width8   2Microsoft.Windows.Controls.DataGridLengthConverter$	 .7* 6   4   .Microsoft.Windows.Controls.DataGridBoundColumn   Binding 5      �� *	PaymentId+  5      -   5        
clmnAmount��$ Cantidad ($)��5      $ 1* 6    5      �� *Amount+  5      -   5        clmnDate��$ Fecha��5      $
 1.2* 6    5      �� *Date+5       �� 5!      -   5         ��Name$ btnAddPayment��5!      $
��Left=�6"   $��40��6=   $��467.104,225.443,0,0q�6I   $	��Top=�6f   $��40��6~    � Cursor$
 Hand��6�    � ToolTip$ Agregar pago��6�   .��5"      �� $��Images/add.png��6   $
��Fill=�6#   5#      �� 5$      -   5        $ btnDeletePayment��5$      $
��Left=�6%   $��40��6@   $��512.104,225.443,0,0q�6L   $	��Top=�6i   $��40��6�   $
 Hand��6�   $ Borrar pago��6�   .��5%      �� $��Images/delete.png��6   $
��Fill=�6&   5&      � 5)      -	   5        $ InputBox��5)   	   $y�	Collapsed=�6   .+�5*      � 
���   � J� Opacity$	 0.5Q�6   �� 5+      $	��250��5,      
��� ���
���   �$��1q�5/       �� CornerRadius$ 	0,55,0,55��50      $��Center=�51      $��Center=�52      ._�53      �� .+�54      �� $��5q�6   $��
Input Box:��6   $
��Bold"�6.   $��Cambria)�6@   �� 55      -
   5         ��Name$ InputTextBox��55   V   $	��150��6   $��Center=�6   $��Center=�6;   6V   �� 56       �� Orientation$ 
Horizontal=�6   $��Center=�6+   .+�57      �� -   5        $ 	YesButton��57      $��5q�6"   $	��Yes��6-   ��6;   Z� 6Q   �� 58      -   5        $ NoButton��58      $��5q�6!   $��No��6,   ��69   Z� 6O   59      5:      5;      5<      �� 5=      -   5        $ btnUpdatePayment��5=      $
��Left=�6%   $��40��6@   $��422.104,225.443,0,0q�6L   $	��Top=�6i   $��40��6�   $
 Hand��6�   $ 
Actualizar��6�   .��5>      �� -   5         ��Name$ imgUpdatePayment��5>      $��Images/update_payment.png��6%   $
��Fill=�6H   5?      �� 5@      -   5         ��Name$ lblTotalCaption��5@   
   $
��Left=�6O   $��30��6j   $��19,235.443,0,0q�6v   $	��Top=�6�   $��Total pagado:��6�   $
��Bold"�6�    �� Target 6#   ��  �� ElementName$ toDatePicker��6�   �� 5A      -   5        $ lblTotal��5A   
   $
��Left=�6H   $��30��6c   $��105.823,235.443,0,0q�6o   $	��Top=�6�   $��$ 100��6�    6   �� $ toDatePicker��6�   5B      5C      