import { IdentityType } from '../common/identity-type';

export class LoginModel
{
	public identityType: IdentityType;
	public countryCallingCode: string;
	public areaCode: string;
	public subscriberNumber: string;
	public emailAddress: string;
	public password: string;
	public persistent: boolean;
}