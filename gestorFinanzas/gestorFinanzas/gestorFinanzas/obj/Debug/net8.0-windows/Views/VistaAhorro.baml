   M S B A M L   `   `   `  ����I  EgestorFinanzas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:gestorFinanzas.viewsgestorFinanzas.views  5   	   !    gestorFinanzas.views.Ahorro   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:gestorFinanzas.views     5   	     � Title$  Ahorro��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��6* �6#   �� 5      $��2* �6#   .+�5      �� $��0��6   $��1��6&    �� Orientation$ 
Horizontal=�5      $��Center=�5      $��Center=�5      $��0,10,0,0q�5      .+�5      �� -   5         ��Name$ txtBuscarNombre��5      $	��250��5      $��30��6   $��14(�5      
�������$"��Ingrese nombre del ahorro...��5!      $��0,0,10,0q�5$      �� 5&      -   5        $��Buscar��5&      $��30��5'      ���#2196F3
�������$
��10,0q�5*      $
��Bold"�5+      5,      5-      �� 51      -   5        $��0��51      $��0��6"   $��Registrar Ahorro��52      $��10,10,18,24q�53      $
��10,5q�6&   ���#4CAF50
�������$
��Bold"�55      $��0q�6#   67   �� 57      -   5        $��1��57      $��Volver��58      $��17,217,10,41q�59      $
��10,5q�6'   ���#E53935
�������$
��Bold"�5;      $��0q�6#   67   �� 5>      -   5         ��Name$ lblDiasRestantes��5>      $��0��62   $��2��6?   $;��5Faltan  días para volver a ingresar dinero al ahorro��5?      $��14(�5@      $
��Wrap=�6"   $��10q�5A      ���#333$��Center=�5B       �� TextAlignment$ Right=�5C      �� 5F      $��1��6   $��1��6&   $��Center=�5G      $��Center=�5H      .+�5K      �� $	��160��6   $	��160��6%    �� CornerRadius$ 80��5L      
�������$��2q�5M   (   
�������._�5O      �� $��Center=�6!   $��Center=�5P      $��10q�5Q      .+�5R      �� $��Dinero Ingresado��6$   $
��Bold"�5S       $��14(�5T       $ Center=�5U       $��0,10,0,5q�5V       �� 5W      -   5        $ lblTotalAhorro��5W   $   $��$��5X       $��24(�5Y       $
��Bold"�5Z       ���#2E7D32$ Center=�5\       5]      5^      5`      �� 5c      -   5        $ lblRestante��5c      $��1��6-   $��1��6:   $&�� Dinero restante para terminar: $��5d      $��14(�5e      $��104,262,104,0q�6"   $	��Top=�5f      ���#3335g      �� 5j      -   5        $��1��5j      $��Ingresar Dinero��5k      $��
0,217,0,41q�5l      $
��10,5q�6%   ���#2196F3
�������$
��Bold"�5n      $��0q�6#   $
��Left=�5o      $	��132��6,   $��2��6M   5q      5r      5s      