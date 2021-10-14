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

## Adventures in Paralelization:
I leave this here as a small note about my attempts to make this run in parallel. The original idea was to run the image processing in parallel, while also drawing it. This was supposed to premmier a new DrawThread component for BasicRender. It'll be able to sequentially handle enqueued requests from asyncronous proccesses. We managed to do it, and while it was somewhat fascinating to see random bits of the image drawn in stripes, and saved *tons* of time in processing, it had a ***massive*** performance cost for drawing.<br/>
<br/>
We ran the approach, and a few others, with a large and small version of this image provided by Shuterstock.<br/>
![](https://image.shutterstock.com/image-photo/closeup-portrait-senior-executive-man-600w-152175194.jpg)<br/>
<br/>
Below are the results and an explination of each approach:<br/>
![](https://cdn.discordapp.com/attachments/335464035921428480/898041394898280458/unknown.png)
|Approach|Description|
|-|-|
|Original|The original approach before the Parallel branch|
|Sequential|Sequential processing of the image, handing the drawing of a colorchar directly after being processed to the drawthread (To make a pixel, we pass two of these)|
|Parallel|Parallel processing of the image, handing the drawing of a colorchar directly after being processed to the drawthread. In order to do this, we must pass a location for the cursor to draw the colorchar at.|
|Sequential (2 at a time)|Sequential processing as above, handing a pixel (2 color chars at the same time) to the drawthread instead of sending two individual requests for each colorchar|
|Parallel (2 at a time)|Parallel processing as above, handing a pixel to the drawthread as done in sequential (2 at a time)|
|Sequential (ENFORCED)|Sequential processing as above, except no cursor location is specified (IE, it is ENFORCED that it is sequential)|
|Hybrid|A hybrid between the new system and the original system. The image is parrallel processed in a background process, and is processed and drawn in the main process at the same time.|
|Parallel then Draw|We parallel process the entire image, then draw it after processing.|

In the end, DrawThread is coming to BasicRender, but it won't be showcased here. I'm honestly surprised that async-ing the process of drawing in this situation resulted in *such slower times* compared to processing then immediately drawing.

Regardless, with this we manage a small improvement to draw times, and drastically improve processing times. If a user only needs to process an image and doesn't require the preview, they can get their desired results a lot faster. Plus we got to learn about Parallel For-s in C# and a little more on tasks (even if it wasn't used here), which was neat.
