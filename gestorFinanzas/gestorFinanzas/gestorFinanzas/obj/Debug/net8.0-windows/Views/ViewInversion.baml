   M S B A M L   `   `   `  ����g  cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 6n    gestorFinanzas(   "gestorFinanzas.Views.ViewInversion   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5   	   Elvc14clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     6n     � Title$  Plataforma Trading Pro��5   	   $	��800��6(   $
��1200��65    � WindowState$ 	Maximized=�5   	    � 	Resources 5         TradingButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value  TradingComboBox  ComboBoxItemStyle  ListViewItemStyle��%Y  &	        &	 �    &	     &	 *    �� 5   
   " ��6&   .�5	      ��  � �� �#3333336+   �� 5
       � �� �#FFFFFF6+   �� 5       � �� �#CCCCCC6,   �� 5       � ��$ 1q�60   �� 5       � ��$
 10 5q�6(   �� 5       � ��$	 5 0q�6'   �� 5       � ��$ Segoe UI Semibold)�6+   �� 5       � ��$ 12(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 3��5   !   ._�5      �� $��Center=�6/   $��Center=�5   -   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5       ��  � �� �#EEEEEE63   5!      5#      �� 5%   
   " ��6(   .�5&      ��  � �� �#3333336+   �� 5'       � �� �#FFFFFF6+   �� 5(       � �� �#CCCCCC6,   �� 5)       � ��$ 1q�60   �� 5*       � ��$ 30��6'   �� 5+       � ��$ Center=�69   �� 5,       � ��$
 Left=�6;   �� 5-       � ��$ 5q�6(   5.      �� 50   
   " ��6*   .�51      ��  � �� �#3333336+   �� 52       � �� �#FFFFFF6+   �� 53       � �� �#CCCCCC6,    54      P� 55      	 �@J�IsMouseOver$

 True��61   . �56      ��  � �� �#EEEEEE63   57      59      �� 5;   
   " ��6*   .�5<      ��  � ��
 �����6+   �� 5=       � ��$ 2q�6'   �� 5>       � ��$ 5q�6(   �� 5?       � �� �#CCCCCC6,   �� 5@       � ��$ 1q�60   �� 5A       � �� 5B      �� 5C      " ��6&   .R�5D      �� #��z��6!   #��z��5E   !   #��z��5F   !   $ 3��5G   !   ._�5H      �� 5I      5J      5L       5M      P� 5N      	 �@J�IsMouseOver$

 True��61   . �5O      ��  � �� �#EEEEEE63   5P      5R      5S      .��5U      �  � RowDefinitions 5V   
   �� 5W      $��0.65* �6   �� 5X      $��0.35* �6   .+�5\   
   � $��0��6    5]      �� 5^      $
��Auto �6    �� 5_      $��* �6    .+�5g      �� $��0��6   
������� �� Padding$ 10q�65   ._�5h      ��  �� Orientation$ 
Horizontal=�6   .+�5i      �� -   5         ��Name$ cmbTipoActivo��5i      $	��120��66   $��0,0,10,0q�6B   #��[ 5j      #��[ 5k       �� SelectedIndex$ -1��5m       �� 
IsEditable$
 True��5n       �� 
IsReadOnly$
 True��5o       �� IsTextSearchEnabled$ False��5p       �� Text$ Invierte en��5q      .@�5r      �� $��Acciones��6'   �� 5s      $��Forex��6'   �� 5t      $��Cripto��6'   5u      �� 5w      -   5         ��Name$ btnActualizar��5w      $��
Actualizar��64   #��[  5x      5y      5z      5{      5   /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  5~      -   5          Name$ 	miGrafico��5~   !   $��1��64   
�������   ZoomMode$ X=�5�   !   ,   &LiveChartsCore.SkiaSharpView.WPF.Chart   TooltipPosition$ Hidden=�5�   !      LegendPosition$ Hidden=�5�   !   5�      � 5�   
   $��1��6   ���#F5F5F5 � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $	��300 �6#   .+�5�      �� $��0��6   $��10q�6%   
�������$ 5��6D   $ 5q�6U   ._�5�      �� -   5         ��Name$ lstInversiones��5�      ��63   �� *Inversiones+ �� View 5�      �� 5�      .P�5�      �� $��ID��6-    �� DisplayMemberBinding 69   �� *IdInversion+�� 5�      $��Activo��6-    6=   �� *Activo.Nombre+�� 5�      $��Cantidad��6-    6?   �� *
Cantidad+�� 5�      $��Precio��6-    6=   �� *Precio+�� 5�      $��Tiempo��6-    6=   �� *Tiempo+�� 5�      $��Acción��6-    �� Width$	 100��6=    �� CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� -   5        $��Vender��5�   1   ���#FF5252
�������$��5q�5�   !   $��2q�5�   !   ��5�   !   �� *IdInversion+5�   !   5�   '   5�      5�      5�      5�      �� 5�      $��1��6   $��
0,10,10,10q�6%   
�������$ 5��6L   $ 15q�6]   ._�5�      �� .+�5�      �� $��COMPRAR ACTIVO��6    $
��Bold"�66   $��14(�6H   $��0,0,0,10q�6V   �� 5�      $��	Cantidad:��6    $��0,5,0,2q�61   �� 5�      -   5         ��Name$ txtCantidad��5�      $��0,0,0,10q�63   �� 5�      $��Precio actual:��6    $��0,5,0,2q�66   �� 5�      -   5          ��Name$  txtPrecioActual��5�       $
��Bold"�69   $��0,0,0,15q�6K   �� 5�      -   5        $��COMPRAR��5�      ���#4CAF50
�������$
��Bold"�5�      $
��10,5q�6/   �� 5�      -	   5        $��VOLVER��5�      ���	#FFE01111
�������$
��Bold"�5�      $
��10,5q�6/   $��0,10,0,0q�6>   5�      5�      5�      5�      5�      