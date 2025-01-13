import { UserProfile } from './../../Interfaces/User/UserProfile';
import { Injectable } from "@angular/core";
import { ApiService } from "./base/api.service";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
	providedIn: 'root'
})

export class ProfilesApiService {
	public constructor(private apiService: ApiService) { }

	public getUserProfiles(userId: number): Observable<UserProfile[]> {
		return this.apiService.get<UserProfile[]>(`profiles/${userId}`);
	}

	public getUserProfile(userId: number, otherUserId: number): Observable<UserProfile> {
		return this.apiService.get<UserProfile>(`profiles/${userId}/details/${otherUserId}`);
	}

	public updateUserProfile(user: UserProfile): Observable<{ }> {
		return this.apiService.put<{ }>(`profiles/${user.id}`, user);
	}
}