import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { ProfilesApiService } from '../shared/services/profiles.api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
  public user: UserProfile | undefined;
  constructor(private profilesApiService: ProfilesApiService) {}

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
}
