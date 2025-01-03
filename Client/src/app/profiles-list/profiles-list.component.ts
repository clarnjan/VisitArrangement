import { Component, OnInit } from '@angular/core';
import { ProfilesApiService } from '../shared/services/profiles.api.service';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profiles-list',
  templateUrl: './profiles-list.component.html',
  styleUrl: './profiles-list.component.css'
})
export class ProfilesListComponent implements OnInit {
  public users: UserProfile[] = [];

  constructor(
    private profilesApiService: ProfilesApiService,
    private router: Router) {}

  ngOnInit(): void {
    this.profilesApiService.getUserProfiles()
      .subscribe((result) => {
        this.users = result;
      });
  }
  
  openProfile(userId: number) {
    this.router.navigate(['profiles', userId]);
  }
}
