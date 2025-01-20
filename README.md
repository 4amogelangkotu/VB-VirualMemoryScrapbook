# VB-VirualMemoryScrapbook

### Overview
Scrapbook Manager is a Windows Forms Application that allows users to create, manage, and share personalized photo scrapbooks. The application simplifies organizing and captioning photos, saving scrapbooks in a portable format that can easily be transferred across devices.

---

### Features
- **Photo Management**: Add, view, caption, and delete photos within a scrapbook.
- **Portable Scrapbooks**: Saves photos in a dedicated `photos` folder alongside the `.sbk` file for easy sharing and use on other devices.
- **Caption Editing**: Update captions for photos on the fly.
- **Error Handling**: Alerts for missing or invalid photo paths.
- **Automatic Selection**: Ensures the first photo is displayed after loading a scrapbook or deleting a photo.
- **User-Friendly Interface**: Simple and intuitive navigation.

---

### File Structure
- **Scrapbook File (`.sbk`)**: A text-based file containing relative paths to photos and their captions.
- **Photos Folder**: Stores all photo files for a scrapbook, ensuring portability.

---

### Technologies Used
- **Programming Language**: Visual Basic (.NET Framework)
- **IDE**: Visual Studio
- **Windows Forms**: For the graphical user interface

---

### How to Use
1. **Add Photos**:
   - Use the "Add" button to include photos in your scrapbook.
   - Assign captions for each photo.
2. **Save Scrapbook**:
   - Save the scrapbook as a `.sbk` file. Photos are automatically stored in a `photos` folder next to the `.sbk` file.
3. **Load Scrapbook**:
   - Open a previously saved `.sbk` file to view and edit your scrapbook.
4. **Edit or Delete**:
   - Modify captions or remove photos as needed.

---

### Setup Instructions
1. Clone or download the repository.
2. Open the project in Visual Studio.
3. Build and run the application.
4. Start creating and managing your scrapbooks!

---

### Future Improvements
- Add support for multiple scrapbook files in a single session.
- Implement drag-and-drop functionality for photos.
- Add an export option for scrapbook files as PDFs.
- Support for photo tagging and searching.

---

### Contributions
Contributions are welcome! Feel free to submit pull requests or open issues to suggest features or report bugs.

---

### License
This project is licensed under the MIT License. See the LICENSE file for more details.
