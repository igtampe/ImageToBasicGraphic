![ItBG](https://cdn.discordapp.com/attachments/335464035921428480/786761225341239336/unknown.png)
ItBG (Image To BasicGraphic) is a converter which can turn regular PNG/JPG Images into BasicGraphic data (Either DrawFile, or HiColor). While it's primarily designed to allow the usage of normal picture editors to make DF and HC files for normal console apps, it can also be used to convert full size pictures.

Due to the fact that usually, console characters are twice as tall as they are wide, each pixel gets turned into two characters. On a 1920x1080 display using Raster fonts 4x6, I can fit an image of *about* 150x200 resolution max.

For more information on BasicGraphics, the DrawFile standard and the HiColorGraphic standards, see [BasicRender](http://github.com/igtampe/basicrender)

## Usage:
Run the executable with the following parameters:
```
ImageToBasicGraphic [Image] [Export] [Mode]

Image  : Filename of the image you wish to convert
Export : Filename to which you wish to save the converted image
Mode   : Mode of conversion (/DF for DrawFile and /HC for HiColor)
```

Alternatively, suply just the filename of an image, and it will display it as a converted HC graphic. This is mostly there for demos of the HiColorGraphic mode.

## Examples:
|Original|DrawFile|HiColor|
|-|-|-|
|![Original](https://cdn.discordapp.com/attachments/335464035921428480/786761848841568284/unknown.png)|![DF](https://cdn.discordapp.com/attachments/297565819494203392/786762292406517800/unknown.png)|![HC](https://cdn.discordapp.com/attachments/335464035921428480/786761886150033468/unknown.png)|
|![Original](https://cdn.discordapp.com/attachments/297565819494203392/786763081367158814/unknown.png)|![DF](https://cdn.discordapp.com/attachments/297565819494203392/786763468479922176/unknown.png)|![HC](https://cdn.discordapp.com/attachments/297565819494203392/786763791190458418/unknown.png)|
|![Original](https://cdn.discordapp.com/attachments/335464035921428480/786764603552038912/unknown.png)|![DF](https://cdn.discordapp.com/attachments/335464035921428480/786764813900185630/unknown.png)|![HC](https://cdn.discordapp.com/attachments/335464035921428480/786765362728796200/unknown.png)|
|![Original](https://cdn.discordapp.com/attachments/335464035921428480/786766284296814592/unknown.png)|![DF](https://cdn.discordapp.com/attachments/335464035921428480/786766384520101908/unknown.png)|![HC](https://cdn.discordapp.com/attachments/335464035921428480/786766657388544020/unknown.png)|
|![Original](https://cdn.discordapp.com/attachments/335464035921428480/786767533222395945/unknown.png)|![DF](https://cdn.discordapp.com/attachments/335464035921428480/786767480034033734/unknown.png)|![HC](https://cdn.discordapp.com/attachments/335464035921428480/786767563908579398/unknown.png)|
|![Original](https://cdn.discordapp.com/attachments/335464035921428480/786768796735242260/unknown.png)|![DF](https://cdn.discordapp.com/attachments/335464035921428480/786769084942516254/unknown.png)|![HC](https://cdn.discordapp.com/attachments/335464035921428480/786769939217252372/unknown.png)|
