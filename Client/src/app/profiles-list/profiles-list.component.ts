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
  public users: UserProfile[] = []; // All users from API
  public filteredUsers: UserProfile[] = []; // Filtered users for display
  public userId = 0;

  public searchQuery: string = ''; // Search field value
  public minRating: number = 0; // Minimum rating filter
  public ratingOptions: number[] = [1, 2, 3, 4, 5]; // Rating options for dropdown

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

    // Fetch profiles with initial filters
    this.fetchProfiles();
  }

  fetchProfiles(): void {
    this.profilesApiService.getUserProfiles(this.userId, this.searchQuery, this.minRating)
      .subscribe((result) => {
        this.users = result;
        this.filteredUsers = result;
      });
  }

  openProfile(userId: number): void {
    if (this.userId > 0) {
      this.router.navigate(['profiles', userId]);
    }
  }
}
