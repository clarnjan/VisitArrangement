import { UserProfile } from './../../Interfaces/User/UserProfile';
import { Injectable } from "@angular/core";
import { ApiService } from "./base/api.service";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
	providedIn: 'root'
})

export class ProfilesApiService {
	public constructor(private apiService: ApiService) { }

	public getUserProfiles(): Observable<UserProfile[]> {
		return this.apiService.get<UserProfile[]>(`profiles`);
	}

	public getUserProfile(userId: number): Observable<UserProfile> {
		return this.apiService.get<UserProfile>(`profiles/${userId}`);
	}

	public updateUserProfile(user: UserProfile): Observable<{ }> {
		return this.apiService.put<{ }>(`profiles/${user.id}`, user);
	}
}