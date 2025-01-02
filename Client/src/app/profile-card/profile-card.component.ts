import { ProfilesApiService } from './../shared/services/profiles.api.service';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FileService } from '../shared/services/file.service';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrl: './profile-card.component.scss'
})
export class ProfileCardComponent implements OnChanges {
  @Input() public user: UserProfile | undefined;
  @Input() public canEdit = false;
  @Input() public isEditing = false;
  public formGroup: FormGroup | undefined;
  @Output() public profilePictureUploaded = new EventEmitter();
  @Output() public saveUpload = new EventEmitter();
  @Output() public isEditingChange = new EventEmitter<boolean>();

  constructor(
    private fileService: FileService) { }
  
  ngOnChanges(): void {
    this.formGroup = new FormGroup({
      firstName: new FormControl(this.user !== undefined ? this.user!.firstName : '' , [Validators.required]),
      lastName: new FormControl(this.user !== undefined ? this.user!.lastName : '', [Validators.required]),
      locationName: new FormControl('')
    });
  } 
  
  public triggerFileInputClick(fileInput: HTMLInputElement) {
    fileInput.click();
  }

  public edit() {
    this.isEditing = true; // Update local state
    this.isEditingChange.emit(this.isEditing); // Emit the updated value
  }

  public uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

    this.profilePictureUploaded.emit(files);
  }
  
  public save() {
    this.user!.firstName = this.formGroup!.get('firstName')?.value;
    this.user!.lastName = this.formGroup!.get('lastName')?.value;
    this.saveUpload.emit(this.user);
  }

  public addLocation() {
    const newLocationName = this.formGroup!.get('locationName')?.value?.trim();
    this.user!.locations.push({ name: newLocationName, images: [] });
    this.formGroup!.get('locationName')?.setValue('');
  }

  public removeLocation(index: number) {
    this.user!.locations.splice(index, 1);
  }

  public uploadImages(event: Event, index: number) {
    const input = event.target as HTMLInputElement;
    if (input.files) {
      const files = Array.from(input.files);
      const images = files.map((file) => `http://localhost:5296/StaticFiles/Images/${file.name}`);
      this.user?.locations[index].images.push(...images);
      
      files.forEach(file => {
        const fileToUpload =  file as File;
        const formData = new FormData();
        formData.append('file', fileToUpload, file.name);
    
        this.fileService.upload(formData)
          .subscribe();
      });
    }
  }
}
