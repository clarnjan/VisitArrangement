import { Component, OnInit } from '@angular/core';
import { ProfilesApiService } from '../shared/services/profiles.api.service';
import { UserProfile } from '../Interfaces/User/UserProfile';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profiles-list',
  templateUrl: './profiles-list.component.html',
  styleUrl: './profiles-list.component.scss'
})
export class ProfilesListComponent implements OnInit {
  public users: UserProfile[] = [];
  public userId = 0;
  public searchQuery: string = ''; 
  public minRating: number = 0; 
  public ratingOptions: number[] = [1, 2, 3, 4, 5]; 

  constructor(
    private profilesApiService: ProfilesApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (typeof window === 'undefined') {
      return;
    }
    const tokenInfo = localStorage.getItem('current-user');
    if (tokenInfo) {
      this.userId = JSON.parse(tokenInfo).userId;
    }

    this.fetchProfiles();
  }

  fetchProfiles(): void {
    this.profilesApiService.getUserProfiles(this.userId, this.searchQuery, this.minRating)
      .subscribe((result) => {
        this.users = result;
      });
  }

  openProfile(userId: number): void {
    if (this.userId > 0) {
      this.router.navigate(['profiles', userId]);
    }
  }
}
