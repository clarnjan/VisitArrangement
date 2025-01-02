import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { ProfilesApiService } from '../shared/services/profiles.api.service';
import { FileService } from '../shared/services/file.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
  public user: UserProfile | undefined;
  public isEditing = false;

  constructor(
    private fileService: FileService,
    private profilesApiService: ProfilesApiService) { }

  ngOnInit(): void {
    if (typeof window === 'undefined'){
      return;
    }
    const tokenInfo = localStorage.getItem('current-user');
    if (!tokenInfo) {
      return;
    }
    
    const userId = JSON.parse(tokenInfo).userId;
    this.profilesApiService.getUserProfile(userId)
      .subscribe((result) => {
        this.user = result;
      });
    }

    public uploadProfilePicture(files: any) {
    
        const fileToUpload =  files[0] as File;
        const formData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);
    
        this.fileService.upload(formData)
        .subscribe((event) => {
           console.log(fileToUpload);
           if (event.type === HttpEventType.Response) {
            this.user!.profilePicture = `http://localhost:5296/StaticFiles/Images/${fileToUpload.name}`;
           }
          }
        );
    }

    public save(user: UserProfile) {
      this.user!.firstName = user.firstName;
      this.user!.lastName = user.lastName;
  
      this.profilesApiService.updateUserProfile(this.user!)
        .subscribe(() => {
          this.isEditing = false;
        });
    }
}
