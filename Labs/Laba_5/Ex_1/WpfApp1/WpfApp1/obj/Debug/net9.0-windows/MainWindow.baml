   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� $��10q�6   .+�5
   
   �� $��Назва заводу:��6   $��5q�6)   �� 5   
   -   5        $��txtName��5      $��5q�6!   �� 5   
   $'��!Місцезнаходження:��6   $��5q�6-   �� 5   
   -   5        $��txtLocation��5      $��5q�6%   �� 5   
   $0��*Кількість працівників:��6   $��5q�62   �� 5   
   -   5        $��txtEmployees��5      $��5q�6&   �� 5   
   $B��<Потужність виробництва (од/день):��6   $��5q�6=   �� 5   
   -   5        $��txtCapacity��5      $��5q�6%   �� 5   
   -   5        $��Зберегти��5      $��10q�67   $��Center=�6C   �� 5   
   -   5        $��Показати��5      $��10q�67   $��Center=�6C   �� 5   
   -   5        $��	txtOutput��5      $
��Wrap=�6M   $��10q�6a   ��6%   �� *Factory.GetFactoryInfo+6a   5      5      