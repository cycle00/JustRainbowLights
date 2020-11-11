# Just Rainbow Lights

This mod makes it so the lights in the background of a level appear rainbow, for a more colourful gameplay experience.

## If you have sensitive eyes, epilepsy, or a history of seizures **DO NOT** install this mod

![Preview](JustRainbowLights/Resources/Images/RainbowLighting.PNG "Preview")

# Usage

Since this is a pre-release and I am bad at programming, I cannot figure out how to create a functional UI, meaning that if you want to load a new preset, you will have to create it manually.

```json
{
  "name": "<the name of your preset>",
  "description": "<the description of your preset>",
  "icon": "<the icon of your preset (see possible icons) (if empty or invalid, will default to default.png)>",
  "color1": {
    "r": "<number 0-1>",
    "g": "<number 0-1>",
    "b": "<number 0-1>",
    "a": "<number 0-1>"
  },
  "color2": {
    "r": "<number 0-1>",
    "g": "<number 0-1>",
    "b": "<number 0-1>",
    "a": "<number 0-1>"
  }
}
```

**Possible Icons:**
```
default.png
cold.png
warm.png
pastel.png
dark.png
```

#### Special Thanks

Special thanks to @Aeroluna and all of the other people who helped me make this mod
