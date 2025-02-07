import { ReviewRequest } from './../../Interfaces/User/UserProfile';
import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ArrangementApiService {
  public constructor(private apiService: ApiService) { }

  public arrangeVisit(userId: number, otherUserId: number): Observable<{}> {
    return this.apiService.post<{}>(`arrangement/${userId}/arrange/${otherUserId}`);
  }
  
  public reviewUser(userId: number, otherUserId: number, reviewRequest: ReviewRequest): Observable<{}> {
    return this.apiService.post<{}>(`arrangement/${userId}/review/${otherUserId}`, reviewRequest);
  }
}
