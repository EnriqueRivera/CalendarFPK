   M S B A M L   `   `   `  ����   FatimasSystem"    FatimasSystem.AddReservation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  Window�� � Title$ Agregar reservación��$	��420��$	��420�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.��� -    �Name$ 
LayoutRoot��.+��� -    ��Name$ lblCurp��$
��Left=�$��30��$��4.999,45,0,0q�$	��Top=� �� Target ��  �� ElementName$ txtCurp��.���� .��*_CURP o ID del cliente:�� -    ��Name$ txtCurp��$
��Left=�$��30��$��139.973,45,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��195��
 �� 	MaxLength$
 20��
 � Tag$ 	CURP o ID��$��0��{�.  �� -   $ lblDepCaption��$��Departamento:��$
��Left=�$��30��$��40.694,10,0,0q�$	��Top=��� -   $ lblDep��$��1��$
��Left=�$��30��$��139.973,10,0,0q�$	��Top=�$
��Bold"��� -   $ lblFromDateCaption��$��Fecha de inicio:��$
��Left=�$��30��$��38.814,80,0,0q�$	��Top=��� -   $ 	lblToDate��$
��Left=�$��30��$��48.441,115,0,0q�$	��Top=� �� $ toDatePicker��.���� .��*_Fecha de fin:(  "System.Windows.Controls.DatePicker  -	     Name$ toDatePicker��$
��Left=�$��30��$��139.971,115,0,0q�$	��Top=�$��230.002����. $��2�� � Cursor$
 Hand���� -
   $ lblFromDate��$��FromDate��$
��Left=�$��30��$��139.972,80,0,0q�$	��Top=��� -   $ lblNumAdults��$
��Left=�$��30��$��9.827,185,0,0q�$	��Top=� �� $ txtNumAdults��.���� .��*Número de _adultos:�� -   $ txtNumAdults��$
��Left=�$��30��$��139.971,185,0,0q�$
	 Wrap=�$	��Top=�$��39.666��$
 2��$ 	CURP o ID��$��4���� -   $ 
lblNumKids��$
��Left=�$��30��$��20.277,150,0,0q�$	��Top=� �� $ 
txtNumKids��.���� .��*Número de _niños:�� -   $ 
txtNumKids��$
��Left=�$��30��$��139.973,150,0,0q�$
	 Wrap=�$	��Top=�$��39.666��$
 2��$ 	CURP o ID��$��3���� -    ��Name$ btnFindGuest��$
��Left=�$��30��$��339.973,45,0,0q�$	��Top=�$��30��$��1��$
 Hand�� � ToolTip$ Buscar clientes��.���� -    ��Name$ imgFind��$��Images/Find.png��$
��Fill=��� -   $ 
lblComment��$
��Left=�$��30��$��55.244,220,0,0q�$	��Top=� �� $ 
txtComment��.���� .��C_omentario:�� -   $ btnAddReservation��$��Agregar��$
��Left=�$��180.269,357,0,0q�$	��Top=�$��55��$��25��$
 Hand��{�.  �� -    ��Name$ 
txtComment��$
��Left=�$��128.667��$��139.971,220,0,0q�$	��Top=�$��265.002��. �/� �� -   $ btnAddClient��$
��Left=�$��30��$��374.973,45,0,0q�$	��Top=�$��30��$��1��$
 Hand��$ Agregar cliente��.���� -   $ imgAddClient��$��Images/add_user.png��$
��Fill=�