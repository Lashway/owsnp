   M S B A M L   `   `   `  ����   
LiveUpdate    LiveUpdate.Window1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml      � Title$  Gateway Real Time��$	��426��$	��820�� � 	Resources ,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled � IsAsynchronous   CharacterData��%  &	        �  .  . .����<Data xmlns="">
                    <Character NodeName="ECG" SensorName="ECG WaveForm" DataType="mv" DataFormat="integer" SamplingFrequency="100" />
                    <Character NodeName="Humidity/Temperature" SensorName="Temperature" DataType="kelvin" DataFormat="float" SamplingFrequency="0.5" />
                    <Character NodeName="Humidity/Temperature" SensorName="Humidity" DataType="" DataFormat="float" SamplingFrequency="0.5" />
                    <Character NodeName="Distance" SensorName="Distance" DataType="cm" DataFormat="float" SamplingFrequency="0.5" />
                    <Character NodeName="Button" SensorName="Button" DataType="bool" DataFormat="int" SamplingFrequency="0.5" />
                    <Character NodeName="Potentiometer" SensorName="Potentiometer" DataType="ohms" DataFormat="int" SamplingFrequency="0.5" />
                    <Character NodeName="Light" SensorName="LDR" DataType="lux" DataFormat="integer" SamplingFrequency="0.5" />
                </Data>        .��� .+�� -   $��MainGrid�� J� Opacity$	 0.9Q�.+�� -    �Name$ 	ChartGrid��$��	0,0,0,143q��� -   $��
statusBar1��$��23��$��Bottom=�� -   $��grid1��$��0,0,0,24q�$	��118��$��Bottom=�.+��� -   $��	listview1������  �� Source# [   �� XPath$ Data/Character�� �� View �� .P��� 	 �� Width$		 150��$
��Node��
 �� CellTemplate
 �� .R��� $��98��$
��-6,0q� �� TextAlignment$
 Left=����� $ 	@NodeName���� $		 150��$��Sensor Name��
 �� .R��� $
��-6,0q�$
 Left=����� $ @SensorName���� $		 150��$��	Data Type��
 �� .R��� $
��-6,0q�$
 Left=����� $ 	@DataType���� $		 150��$��Data Format��
 �� .R��� $
��-6,0q�$
 Left=����� $ @DataFormat���� $		 150��$��Sampling Frequency��
 �� .R��� $
��-6,0q�$
 Left=����� $ @SamplingFrequency��