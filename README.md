<h1 align="center">Unity UI Playables</h1>

Tracks and Clips for controlling the Unity UI (uGUI) with Timeline.

<p align="center">
  <img width=700 src="https://user-images.githubusercontent.com/47441314/113313016-cf9afe80-9345-11eb-9aa9-422c53b5a3f8.gif" alt="Demo">
</p>

## Features

#### Control Unity UI (uGUI)
Unity UI Playables allows you to control any uGUI components and its parameters with Timeline.

<p align="center">
  <img width=700 src="https://user-images.githubusercontent.com/47441314/113312392-34098e00-9345-11eb-9ec4-614caffe09a0.png" alt="Control Unity UI">
</p>

#### Easings and Animation Curve
You can easily set up animations using the easing functions.  
If you want to create complex animations, you can also use Animation Curve.

<p align="center">
  <img width=500 src="https://user-images.githubusercontent.com/47441314/113312417-3a980580-9345-11eb-815b-96baf0f10189.png" alt="Easings and Animation Curve">
</p>

Looping of animations is also possible (Repeat, Reverse, and PingPong are supported as loop types).

#### Blending
All clips and all parameters are blendable.

<p align="center">
  <img width=700 src="https://user-images.githubusercontent.com/47441314/113312482-4c79a880-9345-11eb-8e19-c6c85d2e1338.png" alt="Blending">
</p>

## Setup

#### Requirement
Unity 2019.4 or higher.

#### Install
1. Open the Package Manager from Window > Package Manager
2. "+" button > Add package from git URL
3. Enter the following
    * https://github.com/Haruma-K/UnityUIPlayables.git?path=/Assets/UnityUIPlayables

<p align="center">
  <img width=500 src="https://user-images.githubusercontent.com/47441314/113792801-c1077980-9781-11eb-8770-210999a25c9a.png" alt="Package Manager">
</p>


Or, open Packages/manifest.json and add the following to the dependencies block.

```json
{
    "dependencies": {
        "com.harumak.unityuiplayables": "https://github.com/Haruma-K/UnityUIPlayables.git?path=/Assets/UnityUIPlayables"
    }
}
```

If you want to set the target version, specify it like follow.
* https://github.com/Haruma-K/UnityUIPlayables.git?path=/Assets/UnityUIPlayables#0.1.0

#### License
This software is released under the MIT License.  
You are free to use it within the scope of the license.  
However, the following copyright and license notices are required for use.

* https://github.com/Haruma-K/UnityUIPlayables/blob/master/LICENSE.md

## Usage

#### Create Tracks and Clips
Press the add track button in Timeline and select the track below UnityUIPlayables.

<p align="center">
  <img width=500 src="https://user-images.githubusercontent.com/47441314/113312977-c6aa2d00-9345-11eb-99f5-cd46b718c708.png" alt="Create Tracks and Clips">
</p>

Next, add the corresponding clip to the track.  
The parameters can be controlled from the clip's inspector.

## Controllable Parameters
|Component Name|Parameter Name|
|-|-|
|<b>RectTransform</b>|Anchored Position<br>Size Delta<br>Local Rotation<br>Local Scale|
|<b>Graphic</b>|Color|
|<b>Image</b>|Color<br>Fill Amount|
|<b>RawImage</b>|Color<br>UV Rect|
|<b>Text</b>|Color<br>Font Size<br>Line Spacing|
|<b>Text (Text Mesh Pro)</b>|Font Size<br>Color<br>Gradient (Top Left / Top Right / Bottom Left / Bottom Right)<br>Spacing (Character / Line / Word / Paragraph)<br>Face Color (Only at Runtime)<br>Outline Color (Only at Runtime)<br>Outline Width (Only at Runtime)|
|<b>Slider</b>|Value|
|<b>Canvas Group</b>|Alpha|

## Demo
1. Clone this repository.
2. Open and play the following scene.
    * https://github.com/Haruma-K/UnityUIPlayables/blob/master/Assets/Demo/Scenes/Demo.unity
