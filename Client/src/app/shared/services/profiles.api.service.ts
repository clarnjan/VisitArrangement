import { UserProfile } from './../../Interfaces/User/UserProfile';
import { Injectable } from "@angular/core";
import { ApiService } from "./base/api.service";
import { Observable } from "rxjs/internal/Observable";

import { HttpParams } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})

export class ProfilesApiService {
	public constructor(private apiService: ApiService) { }

	public getUserProfiles(userId: number, searchQuery: string = '', minRating: number = 0): Observable<UserProfile[]> {
		let params = new HttpParams()
			.set('search', searchQuery)
			.set('minRating', minRating.toString());

		return this.apiService.get<UserProfile[]>(`profiles/${userId}`, params);
	}


	public getUserProfile(userId: number, otherUserId: number): Observable<UserProfile> {
		return this.apiService.get<UserProfile>(`profiles/${userId}/details/${otherUserId}`);
	}

	public updateUserProfile(user: UserProfile): Observable<{ }> {
		return this.apiService.put<{ }>(`profiles/${user.id}`, user);
	}
}