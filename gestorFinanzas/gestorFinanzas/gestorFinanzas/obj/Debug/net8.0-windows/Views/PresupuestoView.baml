   M S B A M L   `   `   `  ����  gestorFinanzas*    $gestorFinanzas.Views.PresupuestoView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Presupuesto��5   	   $	��676��6   $
��1250��6*   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��2��6"    �� Orientation$ Vertical=�66   
�������.+�5      �� $��Presupuesto��6   $��20(�6+   $��
ExtraBlack"�69   $��Center=�6Q   $��10q�6l   �� 5      -   5         ��Name$ lblSaldo��5      $��16(�5      $
��Bold"�5      
��� d �$��10q�5      $
��Left=�5      �� 5      $ 
Horizontal=�6   $��	10,5,10,5q�62   .+�5      �� $��Ingreso manual:��6   $��Center=�62   �� 5      -   5         ��Name$ txtIngresoManual��5      $	��120��64   $	��5,0q�6@   �� 5       -   5        $��Agregar Ingreso��5       $	��130��5!      $
��10,0q�6%   ���	#FF4CAF50
�������5$      5%      5&      �� 5)   
   $��1��6   $��2��6"   $ 
Horizontal=�66   $��10q�6O   .+�5*      �� $��Buscar Presupuesto:��6   $��Center=�62   �� 5+      $	��146��6   $��5,0,0,0q�6"   $��51��63   �� 5,      $��Mostrar��6   $��10,0,0,0q�6'   $
��10,5q�69   ���	#FF4CAF50
�������$	��109��6r   $��35��6~   5-      &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ DataGridPresupuestos��50      $��2��51      $��10q�6       AutoGenerateColumns$ False��6,      SelectionMode$ Single=�52      	   HeadersVisibility$	 Column=�6*   
   CanUserAddRows$
 False��53         CanUserDeleteRows$ False��6*      
IsReadOnly$
 True��54         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     57      $ Descripción��6%   $ * 6]    6:   �� *NombreProducto+6]     58      $ Precio��6%   $	 100 6P    65   �� *Precio+6P   5:      � 5=   
   $��3��6   $��10q�6    5>      �� 5?      $
��Auto �6#   �� 5@      $��* �6#   �� 5A      $
��Auto �6#    5C      �� 5D      $
��Auto �6    �� 5E      $
��Auto �6    �� 5F      $
��Auto �6    .+�5I      �� $��Seleccionar Varios��6   $��0��64   $��0��6A   $��Center=�6Q   �� 5J      $��Total:��6   $��1��6%   $��1��62   $��Right=�6B   $
��Bold"�6^   �� 5K      -   5         ��Name$ txtTotal��5K      $	��$ 0��6*   $��1��65   $��2��6B   $
��Bold"�6R   �� 5L      $��Total C/Desc.:��6   $��2��6-   $��1��6:   $��Right=�6J   $
��Bold"�6f   �� 5M      -   5        $ txtTotalConDescuento��5M      $	��$ 0��66   $��2��6A   $��2��6N   $
��Bold"�6^   5N      �� 5Q   
   $��1��6   $��2��6!   $��2��6.   
�������$��1q�6R   $��10q�6f    �� Padding$ 10q�6r   ._�5R      �� .+�5T      �� $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5U      �� $��Descripción:��6   $��80��63   �� 5V      -   5        $ txtDescripcionProducto��5V      $	��100��6>   5W      �� 5Z      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5[      �� $��Precio:��6   $��80��6.   �� 5\      -   5        $ txtPrecioProducto��5\      $	��100��69   5]      �� 5`      -	   5         ��Name$ btnGenerarPDF��5f      $��Gen. PDF��5`      $��0,5,0,0q�5a      $
��10,5q�5b      ���	#FF4CAF50
�������5f      �� 5h      -
   5        $ 
btnGuardar��5h      $��Guardar��6-   $��0,5,0,0q�6?   $
��10,5q�6P   ���	#FF4CAF50
�������6�   �� 5i      -   5        $ btnLimpiarCampos��5i      $��Limpiar��63   $��0,5,0,0q�6E   $
��10,5q�6V   ���	#FF4CAF50
�������6�   �� 5j      -   5        $ btnEliminar��5j      $��Eliminar��6.   $��0,5,0,0q�6A   $
��10,5q�6R   ���	#FF4CAF50
�������6�   �� 5k      -   5        $ 	btnEditar��5k      $��Editar��6,   $��0,5,0,0q�6=   $
��10,5q�6N   ���	#FF4CAF50
�������6�   �� 5l      -   5        $ 	btnVolver��5l      $��Volver��6,   $��0,20,0,0q�6=   $
��10,5q�6O   ���	#FFFF0B0B
�������6�   5m      5n      5o      5p      