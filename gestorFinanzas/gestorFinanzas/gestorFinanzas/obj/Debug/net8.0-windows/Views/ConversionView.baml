   M S B A M L   `   `   `  ����I  EgestorFinanzas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:gestorFinanzas.ViewsgestorFinanzas.Views  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   )    #gestorFinanzas.Views.ConversionView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:gestorFinanzas.Views     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  ConversionView��5	   	   $	��700��6    $
��1000��6-   .��5
      �� ���#eaf8c9._�5   
   � .+�5      �� $��0��6   $	��600��6)   $
��Left=�65   
�������.+�5      �� $$��EQUIVALENCIA DURANTE LA SEMANA��6   $
��Bold"�6B   $��Segoe UI Black)�6T   $��20(�6p   $��	90,30,0,0q�6~   #  LiveCharts.Wpf.CartesianChart  5      $	��547��6%   $��0,50,0,0q�62   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6h   $	��529��6�      Series 6D   �� *SeriesCollection+   AxisX 5        LiveCharts.Wpf.Axis     Title$ Valores��6#      LabelFormatter 63   �� *	Formatter+   AxisY 5        $ Fechas��6#      Labels 62   �� *Labels+   DataTooltip 5      #  LiveCharts.Wpf.DefaultTooltip  5      	   SelectionMode	 SharedYValues6-   5      5      �� 5      $��1��6   $	��400��6)   $��Right=�65   
�������.+�5      �� -   5        
 ��Name$ 
 labelDivisaOrigenSeleccion��5      $	��200��6<   $��24(�6m   $��Segoe UI Black)�6{   $	��De:��6�   $��2,30,0,0q�6�    �� Target 6H   ��  �� ElementName$ monto��6�   �� 5      -   5         ��Name$ monto��5      $	��200��6)   $��30��65   $��-150,40,0,0q�6A   $��Roboto)�6V   �� 5      -   5         ��Name$ divisaOrigenSeleccion��5      $	��100��6:   $��30��6F   $��-40,-30,-190,0q�6R   �� 5      -   5        $!
 labelDivisaDestinoSeleccion��5      $	��200��6=   $��Segoe UI Black)�6   $��24(�6�    J� RenderTransformOrigin$ 
0.48,0.578&�6�   $��A:��6�   $��2,30,0,0q�6�    6I   �� $ divisaDestinoSeleccion��6�   �� 5      -   5        $ montoConvertido��5      $	��200��63   $��30��6?   $��-150,50,0,0q�6K    �� 
IsReadOnly$
 True��6`   $��Roboto)�6r   �� 5       -   5        $ divisaDestinoSeleccion��5       $	��100��6;   $��30��6G   $��150,-30,0,0q�6S    �� Text$ Seleccione la divisa��6h   �� 5!      -   5         ��Name$ botonConvertir��5!   -   $��	Convertir��6   $	��100��6E   $��40��6Q   $��-50,100,0,0q�6]   
����������	#FF4CAF50
�������$��Segoe UI Black)�6�   �� 5"      -   5        $
 labelmontoConvertido��5"      $�� ��66   $	��200��6A   �� 5#      -	   5         ��Name$ detalle��5#      $
��Wrap=�6-   $�� ��6A   $��Arial Rounded MT Bold)�6I   $��20(�6l   �� 5$      -
   5        $ 	btnVolver��5$   *   $��Volver��6   $	��100��6=   $��40��6I   $��
-50,10,0,0q�6U   
����������	#FFF81010
�������$��Segoe UI Black)�6�   5%      5&      5'      5(      