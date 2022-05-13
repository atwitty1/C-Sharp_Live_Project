public ActionResult Create([Bind(Include = "CastMemberId,Name,ProductionTitle,YearJoined,MainRole,Photo,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMember castMember , HttpPostedFileBase castMemberPhotoUpload)
        {
            if (ModelState.IsValid)
            {

                var a = ImagetoByte(castMemberPhotoUpload);
                castMember.Photo = a;
                db.CastMembers.Add(castMember);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            

            return View(castMember);
        }
        
    [HttpPost]
        public byte[] ImagetoByte(HttpPostedFileBase castMemberPhotoUpload)
        {
            byte[] CastMemberImage;
            BinaryReader br = new BinaryReader(castMemberPhotoUpload.InputStream);
            {
                CastMemberImage = br.ReadBytes(castMemberPhotoUpload.ContentLength);
            }
            return CastMemberImage;

      
        }
