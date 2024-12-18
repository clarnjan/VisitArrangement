import { ProfilesApiService } from './../shared/services/profiles.api.service';
import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FileService } from '../shared/services/file.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrl: './profile-card.component.scss'
})
export class ProfileCardComponent implements OnChanges {
  @Input() public user: UserProfile | undefined;
  @Input() public canEdit = false;
  public formGroup: FormGroup | undefined;
  public isEditing = false;
  
  constructor(
    private fileService: FileService,
    private profilesApiService: ProfilesApiService) { }
  
  ngOnChanges(): void {
    this.formGroup = new FormGroup({
      firstName: new FormControl(this.user !== undefined ? this.user!.firstName : '' , [Validators.required]),
      lastName: new FormControl(this.user !== undefined ? this.user!.lastName : '', [Validators.required])
    });
  } 
  
  public triggerFileInputClick(fileInput: HTMLInputElement) {
    fileInput.click();
  }

  public uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

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
  
  public save() {
    this.user!.firstName = this.formGroup!.get('firstName')?.value;
    this.user!.lastName = this.formGroup!.get('lastName')?.value;

    this.profilesApiService.updateUserProfile(this.user!)
      .subscribe(() => {
        this.isEditing = false;
      });
  }
}
