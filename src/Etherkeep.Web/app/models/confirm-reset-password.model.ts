import { IdentityType } from '../common/identity-type';

export class ConfirmResetPasswordModel
{
	public identityType: IdentityType;
	public emailAddress: string;
    public password: string;
    public confirmPassword: string;
    public code: string;
}