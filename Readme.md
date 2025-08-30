# Noita Save Tool

A small WPF utility to manage **save backups** for [Noita](https://store.steampowered.com/app/881100/Noita/).

Noita does not provide any built-in way to back up or restore your save files.  
Mods can add similar features, but they permanently **disable achievements** for that run.  

This tool solves the problem: you can **save and restore your progress** outside the game, and still keep your Steam + in-game achievements intact.

---

## Features

### 🔼💾 Backup Savegame
- Creates a copy of your current `save00` folder.
- The backup is stored as `save00-Backup` in the same directory.
- Use this when you reach a state you want to preserve.

---

### 🔽♻️ Restore Savegame
- **Deletes your current `save00` folder**.
- Replaces it with the contents of the `save00-Backup` folder.
- Use this if you die and want to continue from your last backup state.

⚠️ **Warning:** Restoring will permanently overwrite your current save. Make sure you really want to discard it before running this action.

---

### 📂 Open Save Folder
- Opens the Noita save directory in Windows Explorer:
C:\Users<YourName>\AppData\LocalLow\Nolla_Games_Noita

- Useful if you want to inspect or manage files manually.

---

## Why this tool?
- Noita does not allow reloading saves after death.
- Mods that add this functionality disable achievements for the entire run.
- This tool provides an external, convenient way to back up and restore your runs without touching the game itself.

---

## Notes
- Works only on Windows (where Noita stores saves under `AppData\LocalLow`).
- Only **one backup slot** (`save00-Backup`) is supported at the moment.
- Be careful: restoring will erase your current run if you haven’t backed it up.

---

## License
Free to use and modify for personal use. Not affiliated with Nolla Games.