# YouTube Downloader

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://raw.githubusercontent.com/ebellocchia/auto_mouse_mover/master/LICENSE)

## Introduction

Minimal application to download audio and video from YouTube.\
I originally made this for my dad so he wouldn't use potentially malicious websites to download content from YouTube.

## How it works

[YoutubeExplode](https://github.com/Tyrrrz/YoutubeExplode) is used under the hood to perform the download. The application is basically is a graphical interface to the library.

To download videos, [FFmpeg](https://ffmpeg.org/) is required since YouTube only allows audio-only and video-only streams to be downloaded and they shall be mixed together. FFmpeg can be either installed in the system (i.e. available in system's `PATH`) or simply copied in the same folder of the application.\
FFmpeg can be downloaded from [here](https://github.com/BtbN/FFmpeg-Builds/releases).

The app supports multi-language via localization (a different form is created for each language, which is automatically selected by Windows depending on the system language). The current supported languages are English and Italian, but it can be easily extended to support other languages.

## Building

Just open the Visual Studio solution and build the project in Debug or Release.\
The output folder is *YouTubeDownloader\bin*.

## Usage

The application is made to be as simple as possible to use.\
Just paste the YouTube video URL in the text box, select the desired format (audio/video) and click the download button.

For audio, the highest quality available will be automatically downloaded.\
For video, the user can choose between the highest quality or custom quality.
In the latter case, the user can select the desired video quality between the ones available for the specific video.

## License

This software is available under the MIT license.
