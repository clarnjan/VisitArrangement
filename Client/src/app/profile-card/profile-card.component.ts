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
  @Output() public fileUploadStarted = new EventEmitter();
  @Output() public saveUpload = new EventEmitter();
  @Output() public isEditingChange = new EventEmitter<boolean>();
  
  ngOnChanges(): void {
    this.formGroup = new FormGroup({
      firstName: new FormControl(this.user !== undefined ? this.user!.firstName : '' , [Validators.required]),
      lastName: new FormControl(this.user !== undefined ? this.user!.lastName : '', [Validators.required])
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

    this.fileUploadStarted.emit(files);
  }
  
  public save() {
    this.user!.firstName = this.formGroup!.get('firstName')?.value;
    this.user!.lastName = this.formGroup!.get('lastName')?.value;
    this.saveUpload.emit(this.user);
  }
}
