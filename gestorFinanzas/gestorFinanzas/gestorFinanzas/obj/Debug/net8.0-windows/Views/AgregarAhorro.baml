   M S B A M L   `   `   `  ����I  EgestorFinanzas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:gestorFinanzas.viewsgestorFinanzas.views  5   	   (    "gestorFinanzas.views.AgregarAhorro   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:gestorFinanzas.views     5   	     � Title$  Agregar Ahorro��5   	   $	��450��6    $	��800��6-   .��5	      � $��20q�6   .+�5
   
   �� $��Agregar Ahorro��6   $��Segoe UI Black)�5      $��40(�5      $
��Bold"�5      ���	#FF1E8C00$��Center=�5      $��0,10,0,0q�5      �� 5   
   $'��!Ingrese un nombre para el ahorro:��6   $��Segoe UI Black)�5      $��20(�5      $��	10,80,0,0q�5      $	��Top=�5      �� 5   
   -   5         ��Name$ txtNombreAhorro��5      $	��300��5      $��30��5      $��
400,80,0,0q�5      $	��Top=�5      $
��Left=�5      �� 5    
   $-��'Seleccione el tipo de ahorro que desee:��6   $��Segoe UI Black)�5!      $��20(�5"      $��
10,130,0,0q�5#      $	��Top=�5$      �� 5%   
   -   5         ��Name$ cmbTipoAhorro��5%      $	��300��5&      $��30��5'      $��400,130,0,0q�5(      $	��Top=�5)      $
��Left=�5*      .@�5+      �� $��Inmobiliario��6   �� 5,      $��	Vehículo��6   �� 5-      $��Tecnología��6   �� 5.      $��Viajes��6   �� 5/      $��Emergencias��6   �� 50      $
��Otro��6   51      �� 54   
   $-��'Frecuencia en la que ingresará dinero:��6   $��Segoe UI Black)�55      $��20(�56      $��
10,180,0,0q�57      $	��Top=�58      �� 59   
   -   5        $ cmbFrecuencia��59      $	��300��5:      $��30��5;      $��400,180,0,0q�5<      $	��Top=�5=      $
��Left=�5>      .@�5?      �� $��Diariamente��6   �� 5@      $��Semanalmente��6   �� 5A      $��Quincenalmente��6   �� 5B      $��Mensualmente��6   5C      �� 5F   
   $"��¿Cuánto durará el ahorro?��6   $��Segoe UI Black)�5G      $��20(�5H      $��
10,230,0,0q�5I      $	��Top=�5J      �� 5K   
   -   5        $ cmbDuracion��5K      $	��300��5L      $��30��5M      $��400,230,0,0q�5N      $	��Top=�5O      $
��Left=�5P      .@�5Q      �� $��1 Semana��6   �� 5R      $��15 Días��6   �� 5S      $��1 Mes��6   �� 5T      $��6 Meses��6   �� 5U      $��1 Año��6   �� 5V      $��2 Años��6   5W      �� 5Z   
   -   5        $��Guardar��5Z      $	��100��5[      $��40��5\      $��600,325,0,0q�5]      $	��Top=�5^      $
��Left=�5_      ���#4CAF50
�������$
��Bold"�5b      $��0q�5c      5d      �� 5e   
   -   5        $��Cancelar��5e      $	��100��5f      $��40��5g      $��101,325,0,0q�5h      $	��Top=�5i      $
��Left=�5j      ���#E53935
�������$
��Bold"�5m      $��0q�5n      5o      �� 5r   
   $��¿Cuánto desea ahorrar?��6   $��Segoe UI Black)�5s      $��20(�5t      $��
10,280,0,0q�5u      $	��Top=�5v      �� 5w   
   -   5        $ txtMonto��5w      $	��300��5x   
   $��30��5y   
   $��400,280,0,0q�5z   
   $	��Top=�5{   
   $
��Left=�5|   
   5}   
   5      5�      